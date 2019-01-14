using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_TriangleSort.Model
{
    public class TriangleSorter
    {
        List<Triangle> _triangles;

        public TriangleSorter()
        {

        }

        public TriangleSorter(List<Triangle> triangles)
        {
            _triangles = triangles;
        }

        public void Sort(IComparer<Triangle> comparer)
        {
            _triangles.Sort(comparer);
        }

        public override string ToString()
        {      
            StringBuilder representationBuilder = new StringBuilder();
            representationBuilder.Append("============= Triangles list: ===============\n");
            for (int i = 0; i < _triangles.Count; i++)
            {
                representationBuilder.AppendFormat("{0}. [Triangle {1}]: {2} сm", i+1, _triangles[i].Name, _triangles[i].Area);
                if (i < _triangles.Count - 1)
                {
                    representationBuilder.Append("\n");
                }
            }

            return representationBuilder.ToString();
        }
    }
}
