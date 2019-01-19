using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleSort.Model;

namespace TriangleSort.Tests
{
    [TestClass]
    public class TriangleTest
    {
        [TestMethod]
        [DataRow("triangle1", 5, 6, 7)]
        public void CreateTriangle(string name, double sideA, double sideB, double sideC)
        {
            // Act
            Triangle triangle = Triangle.CreateTriangle(name, sideA, sideB, sideC);

            // Assert
            Assert.IsNotNull(triangle);
        }

        [TestMethod]
        [DataRow("triangle1", 5, 6, 7, 14.7d)]
        public void GetArea(string name, double sideA, double sideB, double sideC, double expected)
        {
            // Arrange
            Triangle triangle = Triangle.CreateTriangle(name, sideA, sideB, sideC);

            // Act
            double real = triangle.GetArea();

            // Assert
            Assert.AreEqual(real, expected);
        }

        [TestMethod]
        [DataRow("triangle1", 5, 6, 7, "triangle2", 4, 5, 6, 1)]
        public void CompareTo(string name1, double sideA1, double sideB1, double sideC1, 
                              string name2, double sideA2, double sideB2, double sideC2, int expected)
        {
            // Arrange
            Triangle triangle1 = Triangle.CreateTriangle(name1, sideA1, sideB1, sideC1);
            Triangle triangle2 = Triangle.CreateTriangle(name2, sideA2, sideB2, sideC2);

            // Act
            int real = triangle1.CompareTo(triangle2);

            // Assert
            Assert.AreEqual(real, expected);
        }
    }
}
