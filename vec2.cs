using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathfinderTest
{
    struct vec2
    {
        public int x, y;

        public vec2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static bool operator== (vec2 a, vec2 b) {
            return a.x == b.x && a.y == b.y;
        }

        public static bool operator !=(vec2 a, vec2 b)
        {
            return !(a == b);
        }

        public static vec2 operator+ (vec2 a, vec2 b)
        {
            return new vec2 { x = a.x + b.x, y = a.y + b.y };
        }

        //Distance formula
        public static double operator* (vec2 a, vec2 b) {
            return Math.Sqrt( Math.Pow(b.x-a.x,2) + Math.Pow(b.y-a.y,2) );
        }
    }
}
