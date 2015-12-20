using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathfinderTest
{
    class DupeKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
    {
        public int Compare(TKey x, TKey y)
        {
            int c = x.CompareTo(y);
            return (c == 0) ? 1 : c;
        }
    }
}
