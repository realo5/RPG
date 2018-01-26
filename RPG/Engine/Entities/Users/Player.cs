using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Engine.Entities.Actors;

namespace RPG.Engine.Entities.Users
{
    [Serializable]
    public class Player : UserRole
    {
        public Actor Actor { get; set; }
        public Player() : base()
        {
            ActorManager actorManager = new ActorManager();
        }

    }
}
