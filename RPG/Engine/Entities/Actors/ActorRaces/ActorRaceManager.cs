using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleRPGExample.Engine.Entities.Actors.ActorRaces
{
    internal class ActorRaceManager : EntityManager
    {
        private List<ActorRace> _races;
        public List<ActorRace> Races { get; }
        public void CreateGoblin()
        {
            _races.Add(new ActorRace());
        }
    }
}
