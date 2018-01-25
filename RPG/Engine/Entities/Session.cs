using System;
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
        private DateTime _dateTime;
        public DateTime DateTime
        {
            get => _dateTime;
        }

        public Session() : base()
        {
            _userManager = new UserManager();
            _dateTime = DateTime.Now;
            Console.WriteLine
                ($"User {_userManager.CurrentUser.Name} logged in as {_userManager.CurrentUser.Role.GetType().Name} at {DateTime}");
        }

        public void Initialize()
        {
            
        }
    }
}
