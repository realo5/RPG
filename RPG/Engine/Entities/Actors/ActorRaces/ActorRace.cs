using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleRPGExample.Entities.Actors.ActorRaces.CreatureTypes;

namespace SimpleRPGExample.Engine.Entities.Actors.ActorRaces
{
    //There can be only one type of each ActorRace
    internal class ActorRace : Entity
    {
        protected CreatureType CreatureType { get; set; }
        public ActorRace(CreatureType type)
        {
            this.CreatureType = type;
        }

    }
}
