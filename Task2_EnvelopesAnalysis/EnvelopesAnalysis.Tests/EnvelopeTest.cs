using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnvelopesAnalysis.Model;

namespace EnvelopesAnalysis.Tests
{
    [TestClass]
    public class EnvelopeTest
    {
        [TestMethod]
        [DataRow(20, 18, 14, 16, 1)]
        public void CompareTo(double height1, double width1, double height2, double width2, int expected)
        {
            // Arrange
            Envelope envelope1 = new Envelope(height1, width1);
            Envelope envelope2 = new Envelope(height2, width2);

            // Act
            int real = envelope1.CompareTo(envelope2);

            // Assert
            Assert.AreEqual(real, expected);
        }
    }
}
