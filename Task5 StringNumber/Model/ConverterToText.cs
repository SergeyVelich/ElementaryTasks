using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_StringNumber.Model
{
    public abstract class ConverterToText
    {
        protected Dictionary<int, string> _first100;
        protected Dictionary<int, string> _first100FemaleChanges;
        protected Dictionary<int, string> _hundreds;
        protected Dictionary<int, string> _multiplesOf1000Form1;
        protected Dictionary<int, string> _multiplesOf1000Form234;
        protected Dictionary<int, string> _multiplesOf1000Form5;
        protected string _negative;
        protected int _maxRank;

        protected abstract void LoadResources();
        public abstract string Convert(int value);
    }
}
