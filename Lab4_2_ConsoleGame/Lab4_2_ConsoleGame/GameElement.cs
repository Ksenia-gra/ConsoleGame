using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_2_ConsoleGame
{
    abstract class GameElement
    {
        private string symbol;
        private List<Point> points=new List<Point>();
        
        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }
        public List<Point> Points
        {
            get { return points; }
            set { points = value; }
        }
        public void Draw()
        {
            foreach(Point point in Points)
            {
                Console.SetCursorPosition(point.X, point.Y);
                Console.Write(Symbol);

            }
        }
        public void Clear()
        {
            foreach (Point point in Points)
            {
                Console.SetCursorPosition(point.X, point.Y);
                Console.Write(" ");

            }
        }
        public bool isCrashed()
        {
            
            if (Points.Any(p => p.X== Game.x-1) || Points.Any(p => p.Y == Game.y - 1 || p.Y==0))
            {
                return true;
            }
               

            return false;

        }
        public bool isHit(List<Point> points1)
        {
            foreach(Point p1 in points1)
            {
                if (Points.Any(p => p == p1))
                {
                    return true;
                }

            }


            return false;
        }
    }
}
