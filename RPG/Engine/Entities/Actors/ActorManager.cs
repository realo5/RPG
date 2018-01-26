using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RPG.Engine.Entities.Actors
{
    class ActorManager : EntityManager
    {
        public ActorManager() : base() { }
        public ActorManager(double seed) : base()
        {
            Create(seed);
        }

        public override void Create()
        {
            Current = new Actor();
        }

        public override void Create(double seed)
        {
            seed = new Random((int)seed).Next();
            Current = new Actor(seed);
        }
        
    }
}
