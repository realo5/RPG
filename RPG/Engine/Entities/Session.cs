﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Engine.Entities.Users;

namespace RPG.Engine.Entities
{
    internal class Session : Entity
    {
        private UserManager _userManager;
        public Session() : base()
        {
            _userManager = new UserManager();
            _userManager.Create(new MenuClient<string>());
        }

    }
}
