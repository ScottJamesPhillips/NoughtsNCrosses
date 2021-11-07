using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsNCrosses.Interfaces
{
	public class User
	{
		public string userInputNum { get; set; }
		public char userSymbol { get; set; }
		public static int NextPlayerNum(int currentPlayer)
		{
			return currentPlayer.Equals(1) ? 2 : 1;
		}

		public static int CheckUserEnterNumber(string userInput)
		{

			bool canConvert = int.TryParse(userInput, out int gamePlaceMarker);
			if (canConvert)
			{
				return gamePlaceMarker;
			}
			else
			{
				throw new Exception("Did you actually enter a number?...");
			}
		}

		public static string GetCurrentUserSymbol(int currentPlayer)
		{
			if (currentPlayer.Equals(1))
			{
				return "X";
			}
			else if (currentPlayer.Equals(2))
			{
				return "O";
			}
			else
			{
				throw new Exception("User number not recognised");
			}
		}
	}
}
