using System;
using System.Collections;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sequences.Model;

namespace Sequences.Tests
{
    [TestClass]
    public class PowSequenceTest
    {
        [TestMethod]
        [DataRow(130, new long[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11})]
        public void GetEnumerator_ByLimits(long upLimit, long[] expectedSequence)
        {
            // Arrange
            PowSequence sequence = new PowSequence(upLimit);

            // Act            
            long[] membersOfSequence = sequence.GetSequence().ToArray();

            // Assert
            Assert.IsTrue(membersOfSequence.SequenceEqual(expectedSequence));
        }
    }
}
