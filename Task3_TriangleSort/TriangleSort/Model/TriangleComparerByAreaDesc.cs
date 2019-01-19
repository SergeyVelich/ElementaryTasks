using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSort.Model
{
    class TriangleComparerByAreaDesc : IComparer<IFigure>
    {
        public int Compare(IFigure x, IFigure y)
        {
            return -x.CompareTo(y);
        }
    }
}
