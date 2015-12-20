using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PathfinderTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int[,] map1 = new int[,] {
                {0,0,0,1,0,0,0,0},
                {0,0,0,1,0,0,0,0},
                {0,0,0,1,0,0,0,0},
                {0,0,0,1,0,0,0,0},
                {0,0,0,1,0,0,0,0}
            };

            string[] map2 = new string[] {
                "###############################",
                "   #                 #        #",
                "#  #  #############  ####  #  #",
                "#     #        #           #  #",
                "#######  #  ####  ##########  #",
                "#  #     #  #     #        #  #",
                "#  #  #######  ####  ####  #  #",
                "#              #     #  #  #  #",
                "#  ###################  #  ####",
                "#        #        #     #     #",
                "#######  #  ####  #  ####  #  #",
                "#     #  #  #     #     #  #  #",
                "#  ####  #  #  ####  #  #  #  #",
                "#           #     #  #  #  #  #",
                "################  ####  #  #  #",
                "#              #  #     #  #  #",
                "#  ##########  #  #  #  #  #  #",
                "#           #     #  #     #  #",
                "#  #######  #######  #######  #",
                "#        #           #         ",
                "###############################"
            };
            var map = Map.makeMap(map2);
            var sp = new SimplePathfinder(map, new vec2(1, 0), new vec2(19, 30), false);

            Console.WriteLine("Started pathfinding...");

            var success = sp.findPath();

            Console.SetCursorPosition(0, map.X);
            Console.WriteLine(String.Format("Done pathfinding! Result: {0}, took {1} iterations for {2} tiles.", success, sp.Iterations, map.X*map.Y));
            Console.ReadLine();
        }
    }
}
