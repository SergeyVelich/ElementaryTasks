using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LuckyTickets.Model;
using System.Linq;

namespace LuckyTickets.Tests
{
    [TestClass]
    public class LuckyTicketsGeneratorPiterTest
    {
        [TestMethod]
        [DataRow((byte)6, 55251)]
        public void Generate(byte quantityDigits, int expected)
        {
            // Arrange
            LuckyTicketsGenerator lackyGenerator = new LuckyTicketsGeneratorMoskow(quantityDigits);

            // Act            
            lackyGenerator.Generate();

            // Assert
            Assert.AreEqual(lackyGenerator.Count(), expected);
        }
    }
}
