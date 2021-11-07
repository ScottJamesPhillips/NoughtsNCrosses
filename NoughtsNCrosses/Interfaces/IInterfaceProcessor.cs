using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsNCrosses.Interfaces
{
	public interface IInterfaceProcessor
	{
		ILogFile mainLog { get; set; }
		IErrorHandler errorHandler { get; set; }
		void CentralProcess();
		//void LogProcessCompletion();
	}
}
