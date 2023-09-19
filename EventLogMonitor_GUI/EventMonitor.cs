using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics.Eventing.Reader;
using System.Xml;
using System.Text;

namespace EventLogMonitor_GUI
{
    public partial class mainForm : Form
    {
        // Get all the available logs (That can be hooked).
        List<String> AvailableLogs = GetAvailableLogs();
        // List of strings that contents all successful hooked logs
        List<String> HookedLogs = new List<string>();
        // List that contains all the events captured. This list is used to export the events.
        List<EventRecord> Events = new List<EventRecord>();
        // EventLogWatcher objects for all the hooked logs. THis list will be used to stop or start the monitoring process.
        List<EventLogWatcher> HookedLogsWatchers = new List<EventLogWatcher>();

        public mainForm()
        {
            InitializeComponent();
        }

        private void MainFormLoaded(object sender, EventArgs e)
        {
            table.CellMouseDoubleClick += ShowLogDetails;
            // log hooking and event capturing function.
            StartEventLogHook(AvailableLogs);
        }

        private void ShowLogDetails(object sender, DataGridViewCellMouseEventArgs e)
        {
            // If the user double clicked on a cell on the "Event Details" colmun, Then display the details for that event.
            if (e.ColumnIndex == 4)
            {
                // The details form. This form will be used later to display the event details.
                ShowDetails sd = new ShowDetails();
                foreach (Control c in sd.Controls)
                {
                    if (c.Name == "textBox1")
                    {
                        // Try retriving the details of the log. If there are no details then do not do any thing.
                        try
                        {
                            TextBox tb = (TextBox)c;
                            tb.Text = table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                            tb.SelectionStart = 0;
                            tb.SelectionLength = 0;
                            sd.Show();
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
        }

        // This function recives a list of event logs to be hooked and add "EventRecordWritten" event for each one.
        private void StartEventLogHook(List<String> logNames)
        {
            foreach (String logName in logNames)
            {
                try
                {
                    EventLogQuery query = new EventLogQuery(logName, PathType.LogName);
                    EventLogWatcher ew = new EventLogWatcher(query);
                    ew.EventRecordWritten += new EventHandler<EventRecordWrittenEventArgs>(OnEntryWritten);
                    ew.Enabled = true;
                    Debug.WriteLine("Registred to : " + logName);
                    HookedLogs.Add(logName);
                    HookedLogsWatchers.Add(ew);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Failed to register: " + logName);
                }
            }
            Debug.WriteLine("Hooked Logs : ");
            foreach (String HookedLog in HookedLogs)
            {
                Debug.WriteLine(HookedLog);
            }

            // enable the "Display Hooked Logs" button when finished hooking.
            DisplayHookedLogsBtn.Enabled = true;

        }

        // This function get triggered every time an event get writen to a hooked log.
        private void OnEntryWritten(object sender, EventRecordWrittenEventArgs e)
        {
            EventRecord entry = e.EventRecord;
            Events.Add(entry);
            DataGridViewRow row = (DataGridViewRow)table.Rows[0].Clone();

            row.Cells[0].Value = entry.TimeCreated;
            row.Cells[1].Value = entry.LogName;
            row.Cells[2].Value = entry.ProviderName;
            row.Cells[3].Value = entry.Id;
            // The following code beautify the XML.
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(entry.ToXml());
            StringWriter sw = new StringWriter();
            xmlDoc.Save(sw);

            row.Cells[4].Value = sw.ToString();
            row.Cells[4].ToolTipText = sw.ToString();

            // Add the new row with the event entry data to the table.
            table.Invoke((MethodInvoker)delegate {
                table.Rows.Add(row);
            });
        }

        // This function get triggered when the clear btn get clicked which clears the events :)
        private void monitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            table.Rows.Clear();
            Events.Clear();
        }

        // Save the events captured to the spicifed path.
        private void SaveReportasXML(String path)
        {
            String Results = "<Events>";
            TextWriter tr = new StreamWriter(path);
            foreach (EventRecord Event in Events)
            {
                Results += Event.ToXml();
            }
            Results += "</Events>";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(Results);
            xmlDoc.Save(tr);
            tr.Flush();
            tr.Close();
        }

        // Save the events captured to the specified CSV path
        private void SaveReportAsCSV(String path)
        {
            // Initialize a StringBuilder to hold the CSV content.
            StringBuilder csvContent = new StringBuilder();

            // Define the header of the CSV file with the desired columns.
            string header = "Time,Log Name,Event Source,EventID,Event Details";
            csvContent.AppendLine(header);

            // Loop through all the EventRecord objects in the Events collection.
            foreach (EventRecord eventRecord in Events)
            {
                // Extract the relevant information from the EventRecord.
                string time = eventRecord.TimeCreated?.ToString("yyyy-MM-dd HH:mm:ss.fff") ?? "N/A"; // TimeCreated is a nullable DateTime
                string logName = eventRecord.LogName ?? "N/A"; // Replace with actual property for log name if it exists
                string eventSource = eventRecord.ProviderName ?? "N/A";
                string eventId = eventRecord.Id.ToString();

                // Extract the Event Details
                string eventDetails = eventRecord.ToXml().Replace(",", ";").Replace("\n", "").Replace("\r", "");

                // Create a new CSV row and append it to csvContent.
                string newLine = $"{time},{logName},{eventSource},{eventId},\"{eventDetails}\"";
                csvContent.AppendLine(newLine);
            }

            // Write the CSV content to the file.
            File.WriteAllText(path, csvContent.ToString());
        }

        // Open dialog for the user to choose where to save the XML report. Then call the function "SaveReportasXML()"
        // to save the report to the chosen path.
        private void exportXML(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            if (sd.ShowDialog() == DialogResult.OK)
            {
                SaveReportasXML(sd.FileName);
            }
        }

        private void exportCSV(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            if (sd.ShowDialog() == DialogResult.OK)
            {
                SaveReportAsCSV(sd.FileName);
            }
        }

        private void SaveReportasJSON(string path)
        {
            //TODO: Implement this function (Low Priority)
        }

        // This will get triggered when the "Display Hooked Logs" get clicked. This will display a MessageBox that 
        // contains all the hooked logs.
        private void displayHookedLogs(object sender, EventArgs e)
        {
            String hookedLogs = $"The following is a list of the logs that are being monitored for changes:{Environment.NewLine}{Environment.NewLine}";

            foreach (String logName in HookedLogs)
            {
                // Example: Construct the full path to the log file.
                // Modify this to accurately represent where your logs are stored.
                string logFilePath = @" C:\Windows\System32\winevt\Logs\" + logName + ".evtx";

                // Get the file size in KB
                FileInfo fileInfo = new FileInfo(logFilePath);
                if (fileInfo.Exists)
                {
                    long sizeInBytes = fileInfo.Length;
                    double sizeInKB = sizeInBytes / 1024.0;

                    // Decide whether to display the size in KB or MB
                    if (sizeInKB < 1024)
                    {
                        hookedLogs += $"{logName} ({sizeInKB:F2} KB){Environment.NewLine}";
                    }
                    else
                    {
                        double sizeInMB = sizeInKB / 1024.0;
                        hookedLogs += $"{logName} ({sizeInMB:F2} MB){Environment.NewLine}";
                    }
                }
                else
                {
                    hookedLogs += $"{logName} (File not found){Environment.NewLine}";
                }
            }

            MessageBox.Show(hookedLogs, "Hooked Logs", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static List<string> GetAvailableLogs()
        {
            // Gell all the event logs that can be hooked and add their names to "logName" list.
            List<String> logNames = new List<String>();
            foreach (EventLog myEvtLog in EventLog.GetEventLogs())
            {
                logNames.Add(myEvtLog.Log);
            }
            // Add the setup event log to the hooked list.
            logNames.Add("Setup");

            return logNames;
        }

        public void StartStopMonitoring()
        {
            foreach (EventLogWatcher ew in HookedLogsWatchers)
            {
                ew.Enabled = !ew.Enabled;
            }

            if (StartorStopMonitoringBtn.BackColor == System.Drawing.Color.Red)
            {
                StartorStopMonitoringBtn.BackColor = System.Drawing.Color.Green;
                StartorStopMonitoringBtn.Text = "Monitoring";
                StartorStopMonitoringBtn.Font = new System.Drawing.Font(StartorStopMonitoringBtn.Font.FontFamily.Name, StartorStopMonitoringBtn.Font.Size,System.Drawing.FontStyle.Bold);
            }
            else
            {
                StartorStopMonitoringBtn.BackColor = System.Drawing.Color.Red;
                StartorStopMonitoringBtn.Text = "Not Monitoring";
                StartorStopMonitoringBtn.Font = new System.Drawing.Font(StartorStopMonitoringBtn.Font.FontFamily.Name, StartorStopMonitoringBtn.Font.Size, System.Drawing.FontStyle.Italic);
            }
        }

        private void StartMonitoringBtn_Click(object sender, EventArgs e)
        {
            StartStopMonitoring();
        }
    }
}
