using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleSort.Resources;

namespace TriangleSort.Model
{
    public class Triangle : IFigure
    {
        public string Name { get; set; }
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public static Triangle CreateTriangle(string name, double sideA, double sideB, double sideC)
        {
            if(sideA >= sideB + sideC || sideB >= sideA + sideC || sideC >= sideB + sideA)
            {
                throw new ArgumentException(MessagesResources.ErrorInvalidTriangleSides);
            }
            return new Triangle(name, sideA, sideB, sideC);
        }

        private Triangle(string name, double sideA, double sideB, double sideC)
        {
            Name = name;
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public double GetArea()
        {

            double SP = (SideA + SideB + SideC) / 2;
            double Area = Math.Round(Math.Sqrt(SP * (SP - SideA) * (SP - SideB) * (SP - SideC)), 2);

            return Area;
        }

        public int CompareTo(IFigure triangle)
        {
            int comparison = GetArea().CompareTo(triangle.GetArea());
            if (comparison == 0)
                comparison = Name.CompareTo(triangle.Name);

            return comparison;
        }
    }
}
