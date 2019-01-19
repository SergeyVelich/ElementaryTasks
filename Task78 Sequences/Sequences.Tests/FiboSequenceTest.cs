using System;
using System.Collections;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sequences.Model;

namespace Sequences.Tests
{
    [TestClass]
    public class FiboSequenceTest
    {
        [TestMethod]
        [DataRow(30, 650, new long[] { 34, 55, 89, 144, 233, 377, 610})]
        public void GetEnumeratorTest(long lowLimit, long upLimit, long[] expectedSequence)
        {
            // Arrange
            FiboSequence sequence = new FiboSequence(lowLimit, upLimit);
            
            // Act
            long[] membersOfSequence = sequence.GetSequence().ToArray();

            // Assert
            Assert.IsTrue(membersOfSequence.SequenceEqual(expectedSequence));
        }
    }
}
