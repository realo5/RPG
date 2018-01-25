using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Engine.Entities.Actors.ActorRaces.CreatureTypes;

namespace RPG.Engine.Entities.Actors.CreatureTypes
{
    class CreatureTypeManager : EntityManager
    {
        private List<CreatureType> _creatureTypes;
        public CreatureTypeManager()
        {

        }
        public void Initialize()
        {

        }
        public CreatureType Retrieve(CreatureTypeKey key)
        {
            CreatureType creatureType;
            StatBlock statblock;

            switch (key)
            {
                case CreatureTypeKey.Aberration:
                    statblock = new StatBlock(new HitDie(1, 8));
                    creatureType = Create(statblock);
                    break;
                case CreatureTypeKey.Animal:
                    statblock = new StatBlock(new HitDie(1, 8));
                    creatureType = Create(statblock);
                    break;
                case CreatureTypeKey.Humanoid:
                    statblock = new StatBlock(new HitDie(1, 8));
                    creatureType = Create(statblock);
                    break;
                default:
                    throw new Exception("Prohibited CreatureType Key Detected");
            }
            return creatureType;
        }

        public void Publish()
        {

        }

        private CreatureType Create(StatBlock statBlock)
        {
            return new CreatureType(statBlock);
        }
    }
}
