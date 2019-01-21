using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileParser.Model;

namespace FileParser.Tests
{
    [TestClass]
    public class ParserTxtTest
    {
        [TestMethod]
        [DataRow("data.txt", "finded", 5)]
        public void GetCountFinded(string path, string pattern, int expected)
        {
            // Arrange
            ParserTxt parser = new ParserTxt(path);

            // Act
            int real = parser.GetCountFinded(pattern);

            // Assert
            Assert.AreEqual(real, expected);
        }

        [TestMethod]
        [DataRow("data.txt", "finded", "replased", 5)]
        public void GetCountReplaced(string path, string pattern, string replacement, int expected)
        {
            // Arrange
            ParserTxt parser = new ParserTxt(path);

            // Act
            int real = parser.GetCountFinded(pattern);

            // Assert
            Assert.AreEqual(real, expected);
        }
    }
}
