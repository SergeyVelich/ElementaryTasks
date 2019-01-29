using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnvelopesAnalysis.Model;

namespace EnvelopesAnalysis.Tests
{
    [TestClass]
    public class EnvelopeComparerTest
    {
        [TestMethod]
        [DataRow(20, 18, 14, 16, 1)]
        [DataRow(12, 18, 14, 16, -1)]
        [DataRow(12, 18, 12, 18, 0)]
        public void Compare(double height1, double width1, double height2, double width2, int expected)
        {
            // Arrange
            EnvelopeComparer comparer = new EnvelopeComparer(2);
            comparer.MainEnvelope = new Envelope(height1, width1);
            comparer.Insert(0, new Envelope(height2, width2));

            // Act
            int real = comparer.Compare(comparer[0]);

            // Assert
            Assert.AreEqual(real, expected);
        }
    }
}
