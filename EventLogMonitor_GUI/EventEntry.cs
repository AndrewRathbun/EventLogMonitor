using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLogMonitor_GUI
{
    [Serializable()]
    public class EventEntry
    {
        public string Category { get; set; }
        public short CategoryNumber { get; set; }
        public string EntryType { get; set; }
        public long EventID { get; set; }
        public int Index { get; set; }
        public string MachineName { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string Time { get; set; }
        public string UserName { get; set; }
    }
}
