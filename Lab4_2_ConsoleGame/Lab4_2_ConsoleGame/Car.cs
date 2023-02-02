using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab4_2_ConsoleGame
{
    enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
        
    }
    internal class Car:GameElement
    {
        private Direction direction=Direction.UP;
        private int step = 1;
        public ConsoleColor CarColor { get; set; }
        public Point StartPosition { get; set; }

        public Car(Point startPoint)
        {
            CarColor = ConsoleColor.Magenta;
            Symbol = "■";
            StartPosition= startPoint;
            Points.Add(StartPosition);
            Points.Add(new Point(startPoint.X+1,startPoint.Y+1));
            Points.Add(new Point(startPoint.X + 1, startPoint.Y));
            Points.Add(new Point(startPoint.X, startPoint.Y + 1));
            Console.ForegroundColor = CarColor;
            Draw();
            
        }

        public void Drive()
        {
            List<Point> newPoints=new List<Point>();
            
            Clear();
            foreach (Point point in Points)
            {
                newPoints.Add(GetNextPosition(point));
            }
            Points =newPoints;
            Draw();
        }
        public Point GetNextPosition(Point point)
        {
            
            Point p = point;
            switch (direction)
            {
                case Direction.LEFT:
                    p.X -= step;
                    break;
                case Direction.RIGHT:
                    p.X += step;
                    break;
                case Direction.UP:
                    p.Y -= step;
                    break;
                case Direction.DOWN:
                    p.Y += step;
                    break;
            }
            return p;
        }
        public void SetDirection(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
            else if (key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
            else if (key == ConsoleKey.UpArrow)
                direction = Direction.UP;
            else if (key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
        }
    }
}
