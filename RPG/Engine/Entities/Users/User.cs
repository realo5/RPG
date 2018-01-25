using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RPG.Engine.Entities;

namespace RPG.Engine.Entities.Users
{
    class User : Entity
    {
        private string _name;
        public string Name
        {
            get => _name;
            private set
            {
                _name = value;
            }
        }

        private UserRole _role;
        public UserRole Role
        {
            get { return _role; }
            set { _role = value; }
        }


        public User(string name, UserRole role)
        {
            //Standard property assignement using the arguments passed in implementation
            Name = name;
            Role = role;

        }
    }
}
