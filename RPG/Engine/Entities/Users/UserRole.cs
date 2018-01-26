﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RPG.Engine.Entities.Actors;

namespace RPG.Engine.Entities.Users
{
    [XmlInclude(typeof(Player))]
    [XmlInclude(typeof(StoryTeller))]
    [Serializable]
    public abstract class UserRole : Entity
    {
        public UserRole()
        {

        }
    }
}