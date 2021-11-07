using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsNCrosses.Interfaces
{
	public interface IErrorHandler
	{
		Boolean ErrorStatus { get; set; }
		string ApplicationRunID { get; set; }
		ILogFile ErrorLog { get; set; }
	}
}
