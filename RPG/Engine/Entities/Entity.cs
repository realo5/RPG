using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Engine.Interfaces;

namespace RPG.Engine.Entities
{
    public abstract class Entity : IEntity
    {
        //All Entities are Publishers
        //public event EntityEventHandler Created;

        private double _seed;
        public double Seed
        { get => _seed; }

        public override string ToString()
        {
            return GetType().Name;
        }

        public event EntityEventHandler EntityEvent;

        protected virtual void OnEntityEvent(object source, EntityEventArgs args)
        {
            EntityEvent?.Invoke(source, args);
        }

        public Entity()
        {
            //When an entity is created we want the manager
            //to fire off a Session if the Entity is ISessionable.
            
        }

        public Entity(double seed)
        {
            _seed = seed;
        }

        //public Entity(EntityCreatedEventArgs args)
        //{
        //    OnCreated(args.Entity);
        //}
        //What an entity will do when it is created.
        //public virtual void OnCreated(Entity source)
        //{
        //    Console.WriteLine
        //        ($"{this.ToString()} created by {source}!");
        //}
    }

}
