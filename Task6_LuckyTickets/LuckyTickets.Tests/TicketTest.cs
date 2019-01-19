using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LuckyTickets.Model;
using System.Linq;

namespace LuckyTickets.Tests
{
    [TestClass]
    public class TicketTest
    {
        [TestMethod]
        [DataRow(0u, (byte)6, new byte[] { 0, 0, 0, 0, 0, 0 })]
        public void CreateTicket(uint number, byte quantityDigits, byte[] expectedNumbersAsDigit)
        {
            // Act
            Ticket ticket = new Ticket(number, quantityDigits);
            
            // Assert
            Assert.IsTrue(ticket.NumbersAsDigit.SequenceEqual(expectedNumbersAsDigit));
        }

        [TestMethod]
        [DataRow(0u, (byte)6, 5, 0)]
        [DataRow(1u, (byte)6, 5, 1)]
        public void Indexer(uint number, byte quantityDigits, int index, int expected)
        {
            // Arrange
            Ticket ticket = new Ticket(number, quantityDigits);

            // Act
            int real = ticket[index];

            // Assert
            Assert.AreEqual(real, expected);
        }

        [TestMethod]
        [DataRow(1u, (byte)6, "000001")]
        public void ToString(uint number, byte quantityDigits, string expected)
        {
            // Arrange
            Ticket ticket = new Ticket(number, quantityDigits);

            // Act
            string real = ticket.ToString();

            // Assert
            Assert.AreEqual(real, expected);
        }
    }
}
