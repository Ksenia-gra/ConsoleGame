using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_2_ConsoleGame
{
    internal class Game
    {
        public static readonly int  x = 60;
        public static readonly int y = 30;

        public static void SetField()
        {
            Console.SetWindowSize(x, y+1);
            Console.SetBufferSize(x, y+1);
            Console.CursorVisible = false;
        }
    }

}
