using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsNCrosses.Interfaces
{
	public interface ILogFile
	{
        string FileAddress { get; set; }
        string mainLogCheckErrorLogMessage { get; }
        string CheckElmahAndErrorLogMessage { get; }
        List<LogFileEntry> Entries { get; set; }
        void AddEntry(string entry);
        void AddErrorEntry(string errorMessage);
        void AddErrorEntry(LogFileEntry errorEntry);
        void AddErrorEntry(string errorMessage, string filename);
        void AddErrorEntry(string errorMessage, string filename, int errorCode);
        void AddExceptionEntry(Exception ex);
        void AddExceptionEntry(Exception ex, string filename);
        string BeautifyLogEntry(LogFileEntry entry, string dateFormat);
        string FormatErrorEntry(LogFileEntry errorEntry, string dateFormat);
    }
}
