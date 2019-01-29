using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessBoard.Model;

namespace ChessBoard.Tests
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        [DataRow(3u, 4u)]
        public void CreateBoard_Result(uint height, uint width)
        {
            // Act
            Board board = new Board(height, width);

            // Assert
            Assert.IsTrue(board.Cells[0, 0].IsBlack != board.Cells[height - 1, width - 1].IsBlack);
        }
    }
}
