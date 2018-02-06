using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Engine.Entities.Users;

namespace RPG.Engine.Entities
{

    public abstract class EntityManager<TEntity> : Entity where TEntity : Entity, new()
    {   
        //The Base class the EntityManager which you will note: is also a descendant of Entity. So, An EntityManager is an Entity...
        //      Entity <-----------------------------------------
        //         |                                            |
        //         v                                            |
        //   EntityManager -> has all the properties of Entity _/
        //        but... ^
        //               |
        //           ActorManager is handled like a typeof(Entity) from within another Manager.
        private List<TEntity> _contents = new List<TEntity>();

        public List<TEntity> Contents
        {
            get => _contents;
            set
            {
                _contents = value;
            }
        }   

        public TEntity Current
        { get; set; }

        public TEntity this[int index]
        {
            get => _contents[index];
        }

        public virtual string Path
        {
            get; set;
        }

        //public event EntityEventHandler EntityCreated;

        //protected virtual void OnEntityCreated(Entity entity)
        //{
        //    EntityCreated?.Invoke
        //        (this, new EntityCreatedEventArgs(entity));
        //}

        public EntityManager()
        {
            
        }

        public EntityManager(double seed)
        {

        }
        //Create default Entity
        public virtual void Create()
        {
            TEntity entity = new TEntity();
            _contents.Add(entity);
            Current = entity;
            //This fires the event.
            //OnEntityCreated(entity);
        }
        public abstract void Edit();
        //Store entire collection
        public abstract void Store();

        public EntityManager(string path)
        {
            Path = path;
            //Still trying to get a working event chain here...
        }
    }
}
