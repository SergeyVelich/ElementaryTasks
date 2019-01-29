using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LuckyTickets.Model;
using LuckyTickets.Resources;
using System.Linq;
using System.ComponentModel;

namespace LuckyTickets.Tests
{
    [TestClass]
    public class TicketTest
    {
        [TestMethod]
        [DataRow(0u, (byte)6, new byte[] { 0, 0, 0, 0, 0, 0 })]
        [DataRow(1u, (byte)6, new byte[] { 0, 0, 0, 0, 0, 1 })]
        [DataRow(569879u, (byte)6, new byte[] { 5, 6, 9, 8, 7, 9 })]
        public void Create_GetResult(uint number, byte quantityDigits, byte[] expectedNumbersAsDigit)
        {
            // Act
            Ticket ticket = Ticket.Create(number, quantityDigits);
            
            // Assert
            Assert.IsTrue(ticket.NumbersAsDigit.SequenceEqual(expectedNumbersAsDigit));
        }

        [TestMethod]
        [DataRow(89898989u, (byte)6)]
        public void Create_GetFail_ArgumentIsTooBig(uint number, byte quantityDigits)
        {
            // Arrange
            Exception ex = null;

            // Act
            try
            {
                Ticket ticket = Ticket.Create(number, quantityDigits);
            }
            catch(ArgumentException e)
            {
                ex = e;
            }
            catch
            {

            }
            
            // Assert
            Assert.IsNotNull(ex);
        }

        [TestMethod]
        [DataRow(0u, (byte)6, 5, 0)]
        [DataRow(1u, (byte)6, 5, 1)]
        [DataRow(569879u, (byte)6, 4, 7)]
        public void Indexer_GetResult(uint number, byte quantityDigits, int index, int expected)
        {
            // Arrange
            Ticket ticket = Ticket.Create(number, quantityDigits);

            // Act
            int real = ticket[index];

            // Assert
            Assert.AreEqual(real, expected);
        }

        [TestMethod]
        [DataRow(569879u, (byte)6, 10, 7)]
        public void Indexer_GetFail_IndexOutOfRangeException(uint number, byte quantityDigits, int index, int expected)
        {
            // Arrange
            Exception ex = null;
            Ticket ticket = Ticket.Create(number, quantityDigits);

            // Act
            try
            {
                int real = ticket[index];
            }
            catch (IndexOutOfRangeException e)
            {
                ex = e;
            }
            catch
            {

            }

            // Assert
            Assert.IsNotNull(ex);
        }

        [TestMethod]
        [DataRow(1u, (byte)6, "000001")]
        public void ToString(uint number, byte quantityDigits, string expected)
        {
            // Arrange
            Ticket ticket = Ticket.Create(number, quantityDigits);

            // Act
            string real = ticket.ToString();

            // Assert
            Assert.AreEqual(real, expected);
        }
    }
}
