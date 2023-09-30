namespace EventLogMonitor_GUI
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.table = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.monitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DisplayHookedLogsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.StartorStopMonitoringBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.adminIndicatorLabel = new System.Windows.Forms.Label();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Channel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Provider = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventMsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.AccessibleName = "table";
            this.table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time,
            this.Channel,
            this.Provider,
            this.EventID,
            this.EventMsg});
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.table.Location = new System.Drawing.Point(0, 24);
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(797, 307);
            this.table.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monitorToolStripMenuItem,
            this.exportLogsToolStripMenuItem,
            this.DisplayHookedLogsBtn,
            this.StartorStopMonitoringBtn,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(797, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // monitorToolStripMenuItem
            // 
            this.monitorToolStripMenuItem.Name = "monitorToolStripMenuItem";
            this.monitorToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.monitorToolStripMenuItem.Text = "Clear";
            this.monitorToolStripMenuItem.Click += new System.EventHandler(this.monitorToolStripMenuItem_Click);
            // 
            // exportLogsToolStripMenuItem
            // 
            this.exportLogsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportCSVToolStripMenuItem,
            this.exportXMLToolStripMenuItem});
            this.exportLogsToolStripMenuItem.Name = "exportLogsToolStripMenuItem";
            this.exportLogsToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.exportLogsToolStripMenuItem.Text = "Export Logs";
            // 
            // exportCSVToolStripMenuItem
            // 
            this.exportCSVToolStripMenuItem.Name = "exportCSVToolStripMenuItem";
            this.exportCSVToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.exportCSVToolStripMenuItem.Text = "Export CSV";
            this.exportCSVToolStripMenuItem.Click += new System.EventHandler(this.exportCSV);
            // 
            // exportXMLToolStripMenuItem
            // 
            this.exportXMLToolStripMenuItem.Name = "exportXMLToolStripMenuItem";
            this.exportXMLToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.exportXMLToolStripMenuItem.Text = "Export XML";
            this.exportXMLToolStripMenuItem.Click += new System.EventHandler(this.exportXML);
            // 
            // DisplayHookedLogsBtn
            // 
            this.DisplayHookedLogsBtn.Enabled = false;
            this.DisplayHookedLogsBtn.Name = "DisplayHookedLogsBtn";
            this.DisplayHookedLogsBtn.Size = new System.Drawing.Size(144, 20);
            this.DisplayHookedLogsBtn.Text = "Display Monitored Logs";
            this.DisplayHookedLogsBtn.Click += new System.EventHandler(this.displayHookedLogs);
            // 
            // StartorStopMonitoringBtn
            // 
            this.StartorStopMonitoringBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.StartorStopMonitoringBtn.BackColor = System.Drawing.Color.Green;
            this.StartorStopMonitoringBtn.ForeColor = System.Drawing.Color.White;
            this.StartorStopMonitoringBtn.Name = "StartorStopMonitoringBtn";
            this.StartorStopMonitoringBtn.Size = new System.Drawing.Size(79, 20);
            this.StartorStopMonitoringBtn.Text = "Monitoring";
            this.StartorStopMonitoringBtn.Click += new System.EventHandler(this.StartMonitoringBtn_Click);
            // 
            // adminIndicatorLabel
            // 
            this.adminIndicatorLabel.AutoSize = true;
            this.adminIndicatorLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.adminIndicatorLabel.Location = new System.Drawing.Point(0, 318);
            this.adminIndicatorLabel.Name = "adminIndicatorLabel";
            this.adminIndicatorLabel.Size = new System.Drawing.Size(67, 13);
            this.adminIndicatorLabel.TabIndex = 2;
            this.adminIndicatorLabel.Text = "Administrator";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.Width = 55;
            // 
            // Channel
            // 
            this.Channel.HeaderText = "Channel";
            this.Channel.Name = "Channel";
            this.Channel.Width = 71;
            // 
            // Provider
            // 
            this.Provider.HeaderText = "Provider";
            this.Provider.Name = "Provider";
            this.Provider.Width = 71;
            // 
            // EventID
            // 
            this.EventID.HeaderText = "EventID";
            this.EventID.Name = "EventID";
            this.EventID.Width = 71;
            // 
            // EventMsg
            // 
            this.EventMsg.HeaderText = "EventDetails";
            this.EventMsg.Name = "EventMsg";
            this.EventMsg.Width = 92;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 331);
            this.Controls.Add(this.adminIndicatorLabel);
            this.Controls.Add(this.table);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.Text = "EventLogMonitor";
            this.Load += new System.EventHandler(this.MainFormLoaded);
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem monitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DisplayHookedLogsBtn;
        private System.Windows.Forms.ToolStripMenuItem StartorStopMonitoringBtn;
        private System.Windows.Forms.ToolStripMenuItem exportCSVToolStripMenuItem;
        private System.Windows.Forms.Label adminIndicatorLabel;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Channel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Provider;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventMsg;
    }
}

