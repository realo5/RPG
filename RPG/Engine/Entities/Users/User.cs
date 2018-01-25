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

        private UserRoleKey _currentRole;

        public UserRoleKey CurrentRole
        {
            get { return _currentRole; }
            set
            {
                _currentRole = value; 
            }
        }

        public User(string name)
        {
            Name = name;
            MenuClient<UserRoleKey> userRoleMenu = new MenuClient<UserRoleKey>();
            userRoleMenu.Prompt = "Choose your initial role";
            foreach (UserRoleKey role in Enum.GetValues(typeof(UserRoleKey)).Cast<UserRoleKey>().ToList<UserRoleKey>())
            {
                userRoleMenu.Selections.Add(role);
            }
            CurrentRole = userRoleMenu.GetUserSelection();

        }
    }
}
