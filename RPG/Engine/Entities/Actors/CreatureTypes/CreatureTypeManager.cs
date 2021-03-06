﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Engine.Entities.Actors.ActorRaces.CreatureTypes;

namespace RPG.Engine.Entities.Actors.CreatureTypes
{
    class CreatureTypeManager : EntityManager<CreatureType>, IManage<CreatureType>
    {
        public CreatureTypeManager() : base()
        {

        }
        public CreatureType Select()
        {
            throw new NotImplementedException();
        }
        public void Retrieve()
        {
            throw new NotImplementedException();
        }
        public void Destroy()
        {
            throw new NotImplementedException();
        }
        public override void Edit()
        {
            throw new NotImplementedException();
        }
        public override void Store()
        {
            throw new NotImplementedException();
        }

        public CreatureType Retrieve(CreatureTypeKey key)
        {
            CreatureType creatureType;
            StatBlock statblock;

            switch (key)
            {
                case CreatureTypeKey.Aberration:
                    statblock = new StatBlock(new HitDie(1, 8));
                    creatureType = Spawn(statblock);
                    break;
                case CreatureTypeKey.Animal:
                    statblock = new StatBlock(new HitDie(1, 8));
                    creatureType = Spawn(statblock);
                    break;
                case CreatureTypeKey.Humanoid:
                    statblock = new StatBlock(new HitDie(1, 8));
                    creatureType = Spawn(statblock);
                    break;
                default:
                    throw new Exception("Prohibited CreatureType Key Detected");
            }
            return creatureType;
        }

        private CreatureType Spawn(StatBlock statBlock)
        {
            return new CreatureType(statBlock);
        }

        public void Publish()
        {

        }

        public override void OnCreated(object source)
        {
            throw new NotImplementedException();
        }

        public override void Create()
        {
            throw new NotImplementedException();
        }
    }
}
