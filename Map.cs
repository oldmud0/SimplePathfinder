using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathfinderTest
{
    class Map
    {
        Tile[,] map;

        public Map(Tile[,] t) {
            this.map = t;
        }

        public int X { get { return map.GetLength(0); } }
        public int Y { get { return map.GetLength(1); } }

        public Tile this[int x, int y] {
            get { return map[x, y]; }
            set { map[x, y] = value; }
        }

        public static Map makeMap(int[,] map)
        {
            Tile[,] t = new Tile[map.GetLength(0), map.GetLength(1)];
            for (int i = 0; i < map.GetLength(0); i++)
                for (int j = 0; j < map.GetLength(1); j++)
                    t[i, j] = new Tile { xy = new vec2 { x = i, y = j }, ttype = map[i, j] == 0 ? Tile.TileType.FREE : Tile.TileType.OBSTACLE };
            return new Map(t);
        }

        public static Map makeMap(string[] map)
        {
            Tile[,] t = new Tile[map.Length, map[0].Length];
            for(int i = 0; i < map.Length; i++)
                for (int j = 0; j < map[0].Length; j++)
                {
                    char c = map[i].ToCharArray()[j];
                    t[i, j] = new Tile { xy = new vec2(i, j), ttype = c == '#' ? Tile.TileType.OBSTACLE : Tile.TileType.FREE };
                }
            return new Map(t);
        }
    }
}
