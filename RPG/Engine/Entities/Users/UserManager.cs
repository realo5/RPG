using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Engine.Entities.Users
{
    class UserManager : EntityManager, IManage
    {
        private List<User> _users = new List<User>();
        public User this[string name]
        {
            get => _users.Find(user => user.Name == name);
        }
        public List<User> Users
        {
            get => _users;
            set => _users = value;
        }

        public UserManager()
        {
            MenuClient<string> stringClient = new MenuClient<string>(); 
            Create(stringClient);
        }

        private void Create(MenuClient<string> userNameClient)
        {
            userNameClient.Prompt = "Enter User name";
            string userName = userNameClient.GetUserInput();
            User newUser = new User(userName);
            Users.Add(newUser);
        }
    }
}
