using NoughtsNCrosses.Interfaces;
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
			bool notValidMove = true;
			do
			{
				try
				{
					User userInput = new User();
					userInput.userInputNum = Console.ReadLine();
					int gamePlaceMarker = User.CheckUserEnterNumber(userInput.userInputNum);
					Board.CheckPositionExists(boardNums, gamePlaceMarker);
					Board.CheckIfPositionFilled(boardNums, gamePlaceMarker);
					if (!string.IsNullOrEmpty(userInput.userInputNum) && Enumerable.Range(1, 9).Contains(gamePlaceMarker))
					{
						Console.Clear();
						boardNums[gamePlaceMarker - 1] = User.GetCurrentUserSymbol(currPlayer);
						notValidMove = false;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			} while (notValidMove);
		}

		public static int CheckWinner(string[] boardNums)
		{
			if (IsGameWinner(boardNums))
				return 1;
			if (IsGameDraw(boardNums))
				return 2;
			else
				return 0;
		}

		public static bool IsGameDraw(string[] boardNums)
		{
			return boardNums[0] != "1" &&
				boardNums[1] != "2" &&
				boardNums[2] != "3" &&
				boardNums[3] != "4" &&
				boardNums[4] != "5" &&
				boardNums[5] != "6" &&
				boardNums[6] != "7" &&
				boardNums[7] != "8" &&
				boardNums[8] != "9";
		}

		public static bool IsGameWinner(string[] boardNums)
		{
			if (IsGameMarkersTheSame(boardNums, 0, 1, 2))
				return true;
			if (IsGameMarkersTheSame(boardNums, 3, 4, 5))
				return true;
			if (IsGameMarkersTheSame(boardNums, 6, 7, 8))
				return true;
			if (IsGameMarkersTheSame(boardNums, 0, 3, 6))
				return true;
			if (IsGameMarkersTheSame(boardNums, 1, 4, 7))
				return true;
			if (IsGameMarkersTheSame(boardNums, 2, 5, 8))
				return true;
			if (IsGameMarkersTheSame(boardNums, 0, 4, 8))
				return true;
			if (IsGameMarkersTheSame(boardNums, 2, 4, 6))
				return true;
			else
				return false;
		}

		public static bool IsGameMarkersTheSame(string[] gameMarkers, int pos1, int pos2, int pos3)
		{
			return gameMarkers[pos1].Equals(gameMarkers[pos2]) && gameMarkers[pos2].Equals(gameMarkers[pos3]);
		}
	}
}
