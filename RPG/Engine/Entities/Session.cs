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
            //You likely noticed that, much like SessionManager traveled to the EntityManager class to retrieve it's base constructor, the Session object itself retrieves a base
            //constructor call to Entity's constructor in the same fashion by inheritence.

            //This is timestamp that we can later use for a variety of reasons...
            _dateTime = DateTime.Now;
            //here we initialize a userManager instance to create a new user based on specifications outlined in later class definitions
            _userManager = new UserManager(_dateTime);
            Console.WriteLine
                ($"User {_userManager.CurrentUser.Name} logged in as {_userManager.CurrentUser.Role.GetType().Name} at {DateTime}");
        }
    }
}
