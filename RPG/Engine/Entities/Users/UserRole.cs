using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Engine.Entities.Actors;

namespace RPG.Engine.Entities.Users
{
    abstract class UserRole : Entity
    {
        protected UserRole()
        {

        }
    }

    class Player : UserRole
    {
        public Actor Actor { get; set; }
        public Player(double seed) : base()
        {
            ActorManager actorManager = new ActorManager(seed);
        }
        
    }

    class StoryTeller : UserRole
    {
        public List<Actor> Actors { get; set; }
        public StoryTeller() : base()
        {
            ActorManager actorManager = new ActorManager();
        }
        
    }
}
