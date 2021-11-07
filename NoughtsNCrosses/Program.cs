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
        //Using this video: https://www.youtube.com/watch?v=jiKf-9MLm7Y
        //Display player signs - who is X and who is O
        //Who's turn is is?
        //Instruct user to enter number between 1 and 9
        //1. Draw game board - Will have 9 cells numbered 1-9
        //2. As user selects the grid they want, will populate that cell with their symbol
        //2.a - judge if winner
        //2.b - if no winner return to step 1
        //2.c - if all markers placed and no winner jusge as draw and stop
        //2.d - if winner, declare them and stop the game
        //Look into video: https://www.youtube.com/watch?v=gTt1iqVs0_U to implement computer aided play also

        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static Random random = new Random();

        private static string appGuid = "01101994-noughts-n-crosses";
        public static string ErrorLogFileName { get; set; } = "noughts-&-crosses_Error.log";
		public static string MainLogFileName { get; set; } = "Main.log";
		public static string AppPath { get; private set; } = AppDomain.CurrentDomain.BaseDirectory;
		static void Main(string[] args)
		{
            LogFile errorLog = new LogFile(Path.Combine(AppPath, ErrorLogFileName));
            try
            {
                IInterfaceProcessor processor;
                ILogFile mainLog = new LogFile(Path.Combine(AppPath, MainLogFileName));
                using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
                {
                    try
                    {
                        if (!mutex.WaitOne(0, false))
                        {
                            string str = "Instance already running";
                            Console.WriteLine(str);
                            errorLog.AddErrorEntry(str);
                            return;
                        }
                        //InitialiseSettings();
                        processor = new InterfaceProcessor(mainLog, new ErrorHandler(new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray()), errorLog));
                        processor.CentralProcess();
                    }
                    catch (Exception ex)
                    {
                        errorLog.AddExceptionEntry(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                errorLog.AddErrorEntry(ex.Message);
            }
        }

        //static void InitialiseSettings()
        //{
        //    try
        //    {

        //    }
        //    catch
        //    {
        //        string str = "Unable to initialise interface. Please App.config data. ";
        //        Console.WriteLine(str);
        //        throw;
        //    }
        //}
    }
}
