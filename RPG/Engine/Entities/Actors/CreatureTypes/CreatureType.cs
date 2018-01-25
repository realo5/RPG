using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Engine.Entities.Actors.CreatureTypes;

namespace RPG.Engine.Entities.Actors.ActorRaces.CreatureTypes
{
    internal class CreatureType : Entity
    {
        public HitDie BaseHitDie{ get; set; }
        public CreatureType(StatBlock statBlock)
        {
            BaseHitDie = statBlock.HD;
        }
    }
}
