using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_2_ConsoleGame
{
    internal class RivalCar:GameElement
    {
        private int step = 1;
        public ConsoleColor RivalCarColor { get; set; }
        public Point StartPosition { get; set; }
        public RivalCar(Point startpoint)
        {
            RivalCarColor = ConsoleColor.Red;
            Symbol = "▼";
            StartPosition = startpoint;
            Points.Add(StartPosition);
            Points.Add(new Point(StartPosition.X + 1, StartPosition.Y + 1));
            Points.Add(new Point(StartPosition.X + 1, StartPosition.Y));
            Points.Add(new Point(StartPosition.X, StartPosition.Y + 1));
            Console.ForegroundColor = RivalCarColor;
            Draw();

        }
        public void Drive()
        {
            List<Point> newPoints = new List<Point>();

            Clear();
            foreach (Point point in Points)
            {
                newPoints.Add(GetNextPosition(point));
            }
            Points = newPoints;
            Draw();
        }
        public Point GetNextPosition(Point point)
        {

            Point p = point;
            p.Y += step;
              
            return p;
        }
    }
}
