using NoughtsNCrosses.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NoughtsNCrosses
{
	class Program
	{
		private static string appGuid = "01101994-noughts-n-crosses";
		public static string ErrorLogFileName { get; set; } = "noughts-&-crosses_Error.log";
		public static string MainLogFileName { get; set; } = "Main.log";
		public static string AppPath { get; private set; } = AppDomain.CurrentDomain.BaseDirectory;
		static void Main(string[] args)
		{
			using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
			{
				try
				{
					if (!mutex.WaitOne(0, false))
					{
						string str = "Instance already running";
						Console.WriteLine(str);
						return;
					}
					//InitialiseSettings();
					InterfaceProcessor processor = new InterfaceProcessor();
					processor.CentralProcess();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				Console.WriteLine("Press any button to close console");
				Console.ReadLine();
			}
		}
	}
}
