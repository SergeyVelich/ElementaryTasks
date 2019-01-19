using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LuckyTickets.Model;
using System.Linq;

namespace LuckyTickets.Tests
{
    [TestClass]
    public class LuckyTicketsGeneratorTest
    {
        [TestMethod]
        [DataRow((byte)6, 55251)]
        public void Count(byte quantityDigits, int expected)
        {
            // Arrange
            LuckyTicketsGenerator lackyGenerator = new LuckyTicketsGeneratorMoskow(quantityDigits);
            lackyGenerator.Generate();

            // Act
            int real = lackyGenerator.Count();

            // Assert
            Assert.AreEqual(real, expected);
        }

        [TestMethod]
        [DataRow(506506u, (byte)6, new bool[] { true, true, true, false, false, false }, true)]
        [DataRow(507506u, (byte)6, new bool[] { true, true, true, false, false, false }, false)]
        [DataRow(506506u, (byte)6, new bool[] { true, false, true, false, true, false }, true)]
        [DataRow(507506u, (byte)6, new bool[] { true, false, true, false, true, false }, false)]
        public void IsLuckyTicket(uint number, byte quantityDigits, bool[] pattern, bool expected)
        {
            // Arrange
            LuckyTicketsGenerator lackyGenerator = new LuckyTicketsGeneratorMoskow(quantityDigits);
            Ticket ticket = new Ticket(number, quantityDigits);

            // Act
            bool real = lackyGenerator.IsLuckyTicket(ticket, pattern);

            // Assert
            Assert.AreEqual(real, expected);
        }
    }
}
