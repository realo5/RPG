using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Engine.Entities.Actors.ActorRaces.CreatureTypes;

namespace RPG.Engine.Entities.Actors.ActorRaces
{
    //There can be only one type of each ActorRace
    public class ActorRace : Entity
    {
        protected CreatureType CreatureType { get; set; }
        public ActorRace() { }
        public ActorRace(CreatureType type)
        {
            this.CreatureType = type;
        }
        public override void OnCreated(object source)
        {
            throw new NotImplementedException();
        }
    }
}
