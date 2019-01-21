using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopesAnalysis.Model
{
    public class Envelope : IComparable<Envelope>
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public Envelope()
        {

        }

        public Envelope(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public int CompareTo(Envelope env)
        {
            if (Math.Max(Height, Width) > Math.Max(env.Height, env.Width) 
                && Math.Min(Height, Width) > Math.Min(env.Height, env.Width))
            {
                return 1;
            }  
            else if(Math.Max(Height, Width) < Math.Max(env.Height, env.Width)
                && Math.Min(Height, Width) < Math.Min(env.Height, env.Width))
            {
                return -1;
            }
            else
                return 0;
        }
    }
}
