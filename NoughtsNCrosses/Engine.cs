﻿using NoughtsNCrosses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsNCrosses
{
	public class Engine
	{
		public static void GameEngine(string[] boardNums, int currPlayer)
		{
			try
			{
				User userInput = new User();
				userInput.userInputNum = Console.ReadLine();
				int gamePlaceMarker = User.CheckUserEnterNumber(userInput.userInputNum);
				Board.CheckPositionExists(boardNums, gamePlaceMarker);
				Board.CheckIfPositionFilled(boardNums, gamePlaceMarker);

				

				if (Enumerable.Range(1, 9).Contains(gamePlaceMarker))
				{
					Console.Clear();
					boardNums[gamePlaceMarker - 1] = User.GetCurrentUserSymbol(currPlayer);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}