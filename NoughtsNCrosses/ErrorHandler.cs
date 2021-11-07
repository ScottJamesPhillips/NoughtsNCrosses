using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsNCrosses.Interfaces
{
	public class ErrorHandler : IErrorHandler
	{
		public ILogFile ErrorLog { get; set; }
		public Boolean ErrorStatus { get; set; } = false;
		public string ApplicationRunID { get; set; }


		public ErrorHandler(string ApplicationRunIDForThisRun, ILogFile errorLog)
		{
			ApplicationRunID = ApplicationRunIDForThisRun;
			ErrorLog = errorLog;
		}
	}
}
