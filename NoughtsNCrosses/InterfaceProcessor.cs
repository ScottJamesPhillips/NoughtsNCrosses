﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsNCrosses.Interfaces
{
	public class InterfaceProcessor:IInterfaceProcessor
	{
		public ILogFile mainLog { get; set; }
		public IErrorHandler errorHandler { get; set; }
		public InterfaceProcessor(ILogFile mainLog, IErrorHandler errorHandler)
		{
			this.errorHandler = errorHandler;
			this.mainLog = mainLog;
		}

		public void CentralProcess()
		{
			try
			{
				string[] boardNum = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
				int currPlayerNum = 10;
				int gameStatus = 0;
				do
				{
					//Console.Clear();
					currPlayerNum = User.NextPlayerNum(currPlayerNum);
					WelcomeMsg();
					Board.DrawGraph(boardNum, currPlayerNum);
					Engine.GameEngine(boardNum, currPlayerNum);
					gameStatus = Engine.CheckWinner(boardNum, currPlayerNum);
				}
				while (gameStatus.Equals(0));
				if (gameStatus.Equals(1))
				{
					WelcomeMsg();
					Board.DrawGraph(boardNum, currPlayerNum);
					Console.WriteLine($"Player {currPlayerNum} is the winner!");
				}
				if (gameStatus.Equals(2))
				{
					WelcomeMsg();
					Board.DrawGraph(boardNum, currPlayerNum);
					Console.WriteLine("It's a tie!");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public static void WelcomeMsg()
		{
			Console.WriteLine("Welcome to tic tac toe....");
			Console.WriteLine("Player 1: X");
			Console.WriteLine("Player 2: O");
		}
	}
}
