using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSort.Model
{
    public class TriangleSorter : ISorter
    {
        public List<IFigure> Triangles { get; set; }

        public TriangleSorter(List<IFigure> triangles)
        {
            Triangles = triangles;
        }       

        public void Sort(IComparer<IFigure> comparer)
        {
            Triangles.Sort(comparer);
        }
    }
}
