using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Engine.Entities.Users;

namespace RPG.Engine.Entities
{
    public class Session : Entity
    {
        private UserManager _userManager;
        private DateTime _dateTime;
        public DateTime DateTime
        {
            get => _dateTime;
        }

        public Session() : base()
        {
           
        }
    }
}
