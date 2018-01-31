using RPG.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Engine.Entities.Items
{
    public abstract class Food : Item, INameable
    {
        public string Presentation
        {
            get; set;
        }
        public string Name { get; set; }
    }
    public class Pie : Food, INameable
    {
        public string Filling
        {
            get; set;
        }
        public string Crust
        {
            get; set;
        }


    }
}
