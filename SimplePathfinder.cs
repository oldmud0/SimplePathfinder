using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathfinderTest
{
    class SimplePathfinder
    {
        Stack<Tile> stack;
        Map map;
        vec2 initialStart, initialEnd;
        bool allowDiagonalMovement;

        int iterations;

        public int Iterations {get {return iterations;}}

        public SimplePathfinder(Map map, vec2 start, vec2 end, bool allowDiagonalMovement)
        {
            this.map = map;
            this.initialStart = start;
            this.initialEnd = end;
            this.allowDiagonalMovement = allowDiagonalMovement;
            stack = new Stack<Tile>();
        }

        public bool findPath()
        {
            iterations = 0;
            bool result = findPath(initialStart, initialEnd);

            Console.Clear();
            printMap();

            return result;
        }

        bool findPath(vec2 start, vec2 end)
        {
            if ((iterations++ & 4) >> 1 == 1)
            {
                Console.Clear();
                printMap();
            }

            if (start == end) return true;

            //Sorted by shortest direct path first
            var q = new SortedList<double, Tile>(allowDiagonalMovement ? 6 : 4, new DupeKeyComparer<double>());
            if (start.x + 1 < map.X) q.Add((start + new vec2 { x = 1, y = 0 }) * end,    map[start.x + 1, start.y]);
            if (start.x - 1 >= 0)    q.Add((start + new vec2 { x = -1, y =  0 }) * end,  map[start.x - 1, start.y]);
            if (start.y + 1 < map.Y) q.Add((start + new vec2 { x = 0, y = 1 }) * end,    map[start.x, start.y + 1]);
            if (start.y - 1 >= 0)    q.Add((start + new vec2 { x =  0, y = -1 }) * end,  map[start.x, start.y - 1]);
            if (allowDiagonalMovement)
            {
                if (start.x + 1 < map.X && start.y + 1 < map.Y) 
                    q.Add((start + new vec2 { x = 1, y = 1 }) * end, map[start.x + 1, start.y + 1]);
                if (start.x + 1 < map.X && start.y - 1 >= 0)
                    q.Add((start + new vec2 { x = 1, y = -1 }) * end, map[start.x + 1, start.y - 1]);
                if (start.x - 1 >= 0 && start.y + 1 < map.Y)
                    q.Add((start + new vec2 { x = -1, y = 1 }) * end, map[start.x - 1, start.y + 1]);
                if (start.x - 1 >= 0 && start.y - 1 >= 0)
                    q.Add((start + new vec2 { x = -1, y = -1 }) * end, map[start.x - 1, start.y - 1]);
            }
            foreach(var p in q) {
                if (p.Value.ttype == Tile.TileType.OBSTACLE || 
                    stack.Count != 0 && stack.Contains(p.Value)) continue;

                stack.Push(map[start.x, start.y]);
                if (findPath(p.Value.xy, end)) return true;
            }
            stack.Pop();
            return false;
        }

        void printMap()
        {
            for (int i = 0; i < map.X; i++)
                for (int j = 0; j < map.Y; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(map[i, j].ttype == Tile.TileType.FREE ? "-" : "#");
                }

            var bufStack = new Stack<Tile>(stack);
            Tile t;
            while (bufStack.Count != 0)
            {
                t = bufStack.Pop();
                Console.SetCursorPosition(t.y, t.x);
                Console.Write("o");
            }

            Console.SetCursorPosition(initialStart.y, initialStart.x);
            Console.Write("S");

            Console.SetCursorPosition(initialEnd.y, initialEnd.x);
            Console.Write("E");
        }
    }
}
