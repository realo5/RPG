using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Engine.Entities;

namespace RPG.Engine
{
    public class EntityCreatedEventArgs : EventArgs
    {
        public Entity Entity { get; set; }
        public EntityCreatedEventArgs(Entity entity)
        {
            Entity = entity;
        }
    }
}
