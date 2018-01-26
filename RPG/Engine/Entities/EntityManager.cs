using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Engine.Entities
{
    internal abstract class EntityManager : Entity, IManage
    {   
        //The Base class the EntityManager which you will note: is also a descendant of Entity. So, An EntityManager is an Entity...
        //      Entity <-----------------------------------------
        //         |                                            |
        //         v                                            |
        //   EntityManager -> has all the properties of Entity _/
        //        but... ^
        //               |
        //           ActorManager is handled like a typeof(Entity) from within another Manager.
        private List<Entity> _contents = new List<Entity>();
        public List<Entity> Contents
        {
            get => _contents;
            set => _contents = value;
        }

        public Entity Current
        { get; set; }

        public Entity this[int index]
        {
            get => _contents[index];
        }

        public EntityManager()
        {
            //If a Manager class is derived from EntityManager, it's own default, parameterless constructor will also call upon this same Create() method from itself.
            Create();
        }

        public EntityManager(double seed)
        {
            Create(seed);
        }

        public abstract void Create();
        public abstract void Create(double seed);
    }
}
