using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Engine.Entities.Users
{
    class UserManager
    {
        private List<User> _users = new List<User>();

        public UserManager()
        {
            MenuClient<string> stringClient = new MenuClient<string>(); 
            _users.Add(Create(stringClient));
        }
        public User Create(MenuClient<string> userNameClient)
        {
            userNameClient.Prompt = "Enter User name";
            string userName = userNameClient.GetUserInput();
            User newUser = new User(userName);
            return newUser;
        }
    }
}
