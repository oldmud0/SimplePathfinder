using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathfinderTest
{
    struct Tile
    {
        public enum TileType
        {
            FREE, OBSTACLE
        }
        public TileType ttype;
        public vec2 xy;
        public int x {get {return xy.x;}}
        public int y {get {return xy.y;}}

        public static bool operator== (Tile a, Tile b) {
            return a.x == b.x && a.y == b.y && a.ttype == b.ttype;
        }

        public static bool operator !=(Tile a, Tile b)
        {
            return !(a == b);
        }
    }
}
