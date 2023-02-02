using System;

namespace Lab4_2_ConsoleGame
{
    internal class Point
    {
        private int x;
        private int y;
        

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        

        public Point (int x,int y)
        {
            X = x; Y=y; 
        }


        public static bool operator ==(Point a, Point b) =>
        (a.X == b.X && a.Y == b.Y) ? true : false;
        public static bool operator !=(Point a, Point b) =>
            (a.X != b.X || a.Y != b.Y) ? true : false;
    }
}