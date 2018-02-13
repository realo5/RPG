using System;
using System.Collections.Generic;
using System.Threading;

namespace ProcWorldGenerator
{
    class Actor
    {
        private int _value;
        public int Value
        {
            get => _value;
            set
            {
                if (value < 0)
                    _value = value * -1;
                else if (value > 9)
                    _value = value -= 9;
            }
        }
        public Actor(int value)
        {
            Value = Value;
        }
    }
    static class Program
    {

        static void Main()
        {
            Random prng = new Random();
            int width = 3;
            int height = 5;
            Actor[,] matrix = new Actor[height, width];
            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                for (int x = 0; x < matrix.GetLength(1); x++)
                {
                    Actor actor = new Actor(prng.Next(0, 9));
                    matrix[y, x] = actor;
                    Console.Write(actor.Value);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }

}
