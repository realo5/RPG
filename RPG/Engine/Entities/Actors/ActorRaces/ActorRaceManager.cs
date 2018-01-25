﻿using System;
using System.Collections;
using System.Collections.Generic;

using RPG.Engine.Entities.Actors.CreatureTypes;

namespace RPG.Engine.Entities.Actors.ActorRaces
{
    internal class ActorRaceManager : EntityManager
    {
        private List<ActorRace> _races;
        public List<ActorRace> Races { get; }
        public void CreateGoblin()
        {
            CreatureTypeManager creatureTypeManager = new CreatureTypeManager();
            _races.Add(new ActorRace(creatureTypeManager.Retrieve(CreatureTypeKey.Humanoid)));
        }
    }
}
