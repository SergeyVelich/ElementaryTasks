using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToText.Model;

namespace NumberToText.Tests
{
    [TestClass]
    public class ConverterToTextENTest
    {
        [TestMethod]
        [DataRow(-212301656L, "Minus two handred twelve million three handred one thousand six handred fifty six")]
        public void Convert_EN(long value, string expected)
        {
            // Arrange
            ConverterToText converter = new ConverterToTextEN();

            // Act
            string real = converter.Convert(value);

            // Assert
            Assert.AreEqual(real, expected);
        }
    }
}
