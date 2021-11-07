using NoughtsNCrosses.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsNCrosses
{
	public class LogFile : ILogFile
	{
		public List<LogFileEntry> Entries { get; set; }
		public string FileAddress { get; set; }
		public string mainLogCheckErrorLogMessage { get; } = $"An error occurred during the execution of a task. Please check the {Program.ErrorLogFileName} error log for details";
		public string CheckElmahAndErrorLogMessage { get; } = $"An error occurred during the execution of a task. Please check the elmah log table or the {Program.ErrorLogFileName} file for the error details.";

		public LogFile(string filePath)
		{
			Entries = new List<LogFileEntry>();
			FileAddress = filePath;
		}

		public void AddEntry(string entry)
		{
			string formattedLogEntry = BeautifyLogEntry(new LogFileEntry(entry), "dd MMM yyyy HH:mm:ss");
			WriteEntryInFile(FileAddress, formattedLogEntry);
			Entries.Add(new LogFileEntry(entry));
		}

		public void AddErrorEntry(string errorMessage, string filename, int errorCode)
		{
			LogFileEntry errorEntry = new LogFileEntry(errorMessage, errorCode, filename);
			string formattedLogEntry = FormatErrorEntry(errorEntry, "dd MMM yyyy HH:mm:ss");
			WriteEntryInFile(FileAddress, formattedLogEntry);
			Entries.Add(errorEntry);
		}
		public void AddErrorEntry(LogFileEntry errorEntry)
		{
			string formattedLogEntry = FormatErrorEntry(errorEntry, "dd MMM yyyy HH:mm:ss");
			WriteEntryInFile(FileAddress, formattedLogEntry);
			Entries.Add(errorEntry);
		}
		public void AddErrorEntry(string errorMessage)
		{
			AddErrorEntry(errorMessage, null, 99);
		}
		public void AddErrorEntry(string errorMessage, string filename)
		{
			AddErrorEntry(errorMessage, filename, 99);
		}

		public void AddExceptionEntry(Exception ex)
		{
			AddExceptionEntry(ex, null);
		}

		public void AddExceptionEntry(Exception ex, string filename)
		{
			if (ex != null)
			{
				string errorMessage = $" Exception Message: { ex.Message}. Stack Trace: {ex.StackTrace}. Type: {ex.GetType().ToString()}.";
				if (ex.InnerException != null)
				{
					errorMessage += $" InnerException: {ex.InnerException.Message}. InnerException Stack Trace: {ex.InnerException.StackTrace}";
				}

				AddErrorEntry(errorMessage, filename, 99);
			}
		}

		void WriteEntryInFile(string logFilePath, string formattedLogEntry)
		{
			try
			{
				File.AppendAllText(logFilePath, formattedLogEntry);
			}
			catch (Exception ex)
			{
				string directory = Path.GetDirectoryName(logFilePath);
				string newFilePath = Path.Combine(directory, $"ERROR_{Path.GetFileNameWithoutExtension(logFilePath)}_{DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss_fff")}.log");
				var newEntry = $"{formattedLogEntry} {Environment.NewLine} Exception Writing Entry to file. Exception Message: {ex.Message}. Stack trace: {ex.StackTrace}";
				File.AppendAllText(newFilePath, newEntry);
			}
		}

		public string BeautifyLogEntry(LogFileEntry logEntry, string dateFormat)
		{
			return logEntry.DateStamp.ToString(dateFormat) + " : " + logEntry.Entry + Environment.NewLine;
			//"dd MMM yyyy HH:mm:ss"
		}
		public string FormatErrorEntry(LogFileEntry errorEntry, string dateFormat)
		{
			string formattedErrorEntry = "";

			if (errorEntry.Filename != null && errorEntry.Filename != "")
			{
				formattedErrorEntry = $"{errorEntry.DateStamp.ToString(dateFormat)} - ERROR {errorEntry.Code} : ({errorEntry.Filename}) : {errorEntry.Entry}" + Environment.NewLine;

			}
			else
			{
				formattedErrorEntry = $"{errorEntry.DateStamp.ToString(dateFormat)} - ERROR {errorEntry.Code} : {errorEntry.Entry}" + Environment.NewLine;
			}

			return formattedErrorEntry;
		}
	}
}
