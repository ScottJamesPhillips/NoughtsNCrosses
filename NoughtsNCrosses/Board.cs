using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsNCrosses.Interfaces
{
	public class Board
	{
		public static void DrawGraph(string[] boardNum, int playerNum)
		{
			Console.WriteLine($"Player {playerNum}'s turn - please select a location to place your symbol.");
			Console.WriteLine("");
			Console.WriteLine($" {boardNum[0]} | {boardNum[1]} | {boardNum[2]} ");
			Console.WriteLine("---+---+---");
			Console.WriteLine($" {boardNum[3]} | {boardNum[4]} | {boardNum[5]} ");
			Console.WriteLine("---+---+---");
			Console.WriteLine($" {boardNum[6]} | {boardNum[7]} | {boardNum[8]} ");
			Console.WriteLine("");
		}

		public static void CheckIfPositionFilled(string[] boardNums, int gamePlaceMarker)
		{
			string currentMarker = boardNums[gamePlaceMarker - 1];
			//check if already used
			if (currentMarker.Equals("X") || currentMarker.Equals("O"))
			{
				throw new Exception($"Place '{gamePlaceMarker}' has already been assigned.");
			}
		}

		public static void CheckPositionExists(string[] boardNums, int gamePlaceMarker)
		{
			if (Array.IndexOf(boardNums, gamePlaceMarker.ToString())==-1)
			{
				throw new Exception($"Place '{gamePlaceMarker}' does not exist on play board.");
			}
		}
	}
}
