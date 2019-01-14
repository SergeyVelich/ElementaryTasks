using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_TriangleSort.Model
{
    class TriangleComparerByAreaDesc : IComparer<Triangle>
    {
        public int Compare(Triangle x, Triangle y)
        {
            return -x.CompareTo(y);
        }
    }
}
