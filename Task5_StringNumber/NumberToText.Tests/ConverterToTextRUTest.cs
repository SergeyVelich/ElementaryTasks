using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToText.Model;

namespace NumberToText.Tests
{
    [TestClass]
    public class ConverterToTextRUTest
    {
        [TestMethod]
        [DataRow(-212301656L, "Минус двести двенадцать миллионов триста одна тысяча шестьсот пятьдесят шесть")]
        public void Convert_RU(long value, string expected)
        {
            // Arrange
            ConverterToText converter = new ConverterToTextRU();

            // Act
            string real = converter.Convert(value);

            // Assert
            Assert.AreEqual(real, expected);
        }
    }
}
