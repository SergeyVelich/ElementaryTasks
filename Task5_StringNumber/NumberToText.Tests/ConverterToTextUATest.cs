using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToText.Model;

namespace NumberToText.Tests
{
    [TestClass]
    public class ConverterToTextUATest
    {
        [TestMethod]
        [DataRow(-212301656L, "Мінус двісті дванадцять мільйонів триста одна тисяча шістсот п'ятдесят шість")]
        public void Convert_UA(long value, string expected)
        {
            // Arrange
            ConverterToText converter = new ConverterToTextUA();

            // Act
            string real = converter.Convert(value);

            // Assert
            Assert.AreEqual(real, expected);
        }
    }
}
