using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Engine.Entities
{
    public abstract class Entity : IEntity
    {
        private double _seed;
        public double Seed
        { get => _seed; }

        public override string ToString()
        {
            return GetType().Name;
        }

        public Entity()
        {
            //OnCreated(this);
        }
        public Entity(double seed)
        {
            _seed = seed;
        }

        public abstract void OnCreated(object source);
    }

}
