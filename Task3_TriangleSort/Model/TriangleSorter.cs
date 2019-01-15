using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_TriangleSort.Model
{
    public class TriangleSorter
    {
        public List<Triangle> Triangles { get; set; }

        public TriangleSorter()
        {

        }

        public TriangleSorter(List<Triangle> triangles)
        {
            Triangles = triangles;
        }       

        public void Sort(IComparer<Triangle> comparer)
        {
            Triangles.Sort(comparer);
        }
    }
}
