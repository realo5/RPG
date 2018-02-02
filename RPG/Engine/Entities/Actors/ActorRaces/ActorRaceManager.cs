using System;
using System.Collections;
using System.Collections.Generic;

using RPG.Engine.Entities.Actors.CreatureTypes;

namespace RPG.Engine.Entities.Actors.ActorRaces
{
    public class ActorRaceManager : EntityManager<ActorRace>, IManage<ActorRace>
    {
        private List<ActorRace> _races;
        public List<ActorRace> Races { get; }

        public override void Create()
        {
            throw new NotImplementedException();
        }

        public void CreateGoblin()
        {
            CreatureTypeManager creatureTypeManager = new CreatureTypeManager();
            _races.Add(new ActorRace(creatureTypeManager.Retrieve(CreatureTypeKey.Humanoid)));
        }

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

        public ActorRace Select()
        {
            throw new NotImplementedException();
        }

        public override void Store()
        {
            throw new NotImplementedException();
        }
    }
}
