using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleRPGExample.Engine.Entities.Actors.CreatureTypes;

namespace SimpleRPGExample.Engine.Entities.Actors.ActorRaces.CreatureTypes
{
    internal class CreatureType : Entity
    {
        public int HitDice { get; set; }
        public CreatureType(CreatureTypeKey key)
        {

        }
    }
}
