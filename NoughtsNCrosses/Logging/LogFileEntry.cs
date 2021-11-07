using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsNCrosses
{
	public class LogFileEntry
	{
        public string Entry { get; set; }
        public DateTime DateStamp { get; set; }
        public int Code { get; set; } = 0; //code is for errorlogs
        public string Filename { get; set; } = "";

        public LogFileEntry(string entry)
        {
            Entry = entry;
            DateStamp = DateTime.Now;
        }
        public LogFileEntry(string entry, int code, string filename)
        {
            Entry = entry;
            DateStamp = DateTime.Now;
            Code = code;
            Filename = filename;
        }
    }
}
