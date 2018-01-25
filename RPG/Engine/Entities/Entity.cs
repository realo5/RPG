using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Engine.Entities
{
    internal abstract class Entity : IEntity
    {
        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
