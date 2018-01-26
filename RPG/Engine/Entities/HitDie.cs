using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Engine.Entities
{
    public struct HitDie
    {
        public int Amount { get; set; }
        public int Sides { get; set; }
        public HitDie(int amount, int sides) : this()
        {
            Amount = amount;
            Sides = sides;
        }
        public int Roll()
        {
            Console.Write($"{Amount}D{Sides}: ");
            Random rng = new Random();
            int result = 0;

            for (int i = 0; i < Amount; i++)
                result += rng.Next(1, Sides);

            return result;
        }
        public int Roll(int modifier)
        {
            Console.Write($"{Amount}D{Sides}: ");
            Random rng = new Random();
            int result = 0;

            for (int i = 0; i < Amount; i++)
                result += rng.Next(1, Sides);

            return result + modifier;
        }
    }
}
