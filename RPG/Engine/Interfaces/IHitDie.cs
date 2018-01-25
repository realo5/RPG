using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Engine.Entities;

namespace RPG.Engine.Interfaces
{
    internal interface IHitDie
    {
        HitDie HD { get; set; }
        int Roll();
    }
}
