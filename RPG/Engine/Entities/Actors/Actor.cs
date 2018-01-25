using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Engine.Entities.Actors.ActorRaces;

namespace RPG.Engine.Entities.Actors
{
    class Actor : Entity
    {
        public ActorRace Race { get; set; }
        public Actor()
        {

        }
    }
}
