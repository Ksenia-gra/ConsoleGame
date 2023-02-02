using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_2_ConsoleGame
{
    internal class Coin:GameElement
    {
        public ConsoleColor CoinColor { get; set; }
        public Coin(Point startpoint) 
        {
            Symbol = "$";
            CoinColor= ConsoleColor.Green;
            Points.Add(startpoint);
            Console.ForegroundColor = CoinColor;
            Draw();
        }   
    }
}
