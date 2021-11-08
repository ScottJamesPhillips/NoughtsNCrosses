using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoughtsNCrosses;
using NoughtsNCrosses.Interfaces;
using System;

namespace NoughtsNCrossesTests
{
	[TestClass]
	public class NoughtsNCrossesTests
	{
		[TestMethod]
		public void EnsurePlayersAlternate()
		{
			int currPlayer = 2;
			int nextPlayer = User.NextPlayerNum(currPlayer);
			Assert.AreNotEqual(currPlayer, nextPlayer);
			Assert.AreEqual(nextPlayer, 1);
		}

		[TestMethod]
		[ExpectedException(typeof(Exception),
	"User number not recognised")]
		public void PreventDodgeyUserNumberGettingSymbol()
		{
			int currPlayer = 10000;
			User.GetCurrentUserSymbol(currPlayer);
		}

		[TestMethod]
		public void EnsureWinnerCheckWorks()
		{
			string[] winBoard = { "X", "X", "X", "O", "5", "6", "7", "O", "O", "9", };
			bool hasWon = Engine.IsGameWinner(winBoard);
			Assert.IsTrue(hasWon);
			string[] noWinBoard = { "X", "2", "O", "4", "5", "6", "7", "8", "9" };
			bool hasntWon = Engine.IsGameWinner(noWinBoard);
			Assert.IsFalse(hasntWon);
		}

		[TestMethod]
		public void EnsureDrawCheckWorks()
		{
			string[] drawBoard = { "X", "O", "X", "O", "X", "O", "X", "O", "X" };
			bool hasDrawn = Engine.IsGameDraw(drawBoard);
			Assert.IsTrue(hasDrawn);
		}

		[TestMethod]
		public void CheckWinBeforeCheckDraw()
		{
			string[] winBoard = { "X", "O", "X", "O", "X", "O", "X", "O", "X" };
			int result = Engine.CheckWinner(winBoard);
			//Winner result 1, draw result 2...
			Assert.AreEqual(1, result);
		}

		[TestMethod]
		[ExpectedException(typeof(Exception),
	"Did you actually enter a number?...")]
		public void EnsureLetterNotExcepted()
		{
			string test = "testing";
			User.CheckUserEnterNumber(test);
		}

		[TestMethod]
		[ExpectedException(typeof(Exception),
	"Place '11' does not exist on play board.")]
		public void EnsurenumberOffBoardNotExcepted()
		{
			int marker = 11;
			string[] boardNums = { "X", "2", "3", "4", "5", "6", "7", "8", "9" };
			Board.CheckPositionExists(boardNums, marker);
		}

		[TestMethod]
		[ExpectedException(typeof(Exception),
	"Place '1' has already been assigned.")]
		public void EnsurePositionFilledCheckWorks()
		{
			string[] boarNums = { "X", "2", "3", "4", "5", "6", "7", "8", "9" };
			int marker = 1;
			Board.CheckIfPositionFilled(boarNums, marker);
		}
	}
}
