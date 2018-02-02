using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RPG.Engine.Entities.Actors
{
    class ActorManager : EntityManager<Actor>, IManage<Actor>
    {
        public ActorManager() : base() { }
        public ActorManager(double seed) : base()
        {
            //Create(seed);
        }

        public override void Create()
        {
            Actor newActor = new Actor();
            Contents.Add(newActor);
            Current = newActor;
        }

        //public override void Create(double seed)
        //{
        //    seed = new Random((int)seed).Next();
        //    Current = new Actor(seed);
        //}

        public void Destroy()
        {
            throw new NotImplementedException();
        }

        public override void Edit()
        {
            throw new NotImplementedException();
        }

        public override void OnCreated(object source)
        {
            throw new NotImplementedException();
        }

        public void Retrieve()
        {
            throw new NotImplementedException();
        }

        public Actor Select()
        {
            throw new NotImplementedException();
        }

        public override void Store()
        {
            throw new NotImplementedException();
        }
    }
}
