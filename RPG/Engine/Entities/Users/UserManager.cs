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

        public User CurrentUser
        { get;set; }

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
            CurrentUser = Create();
            Console.WriteLine($"Logged in as {CurrentUser.Name}.");
        }

        private User Create()
        {
            MenuClient<string> userStringClient = new MenuClient<string>();

            userStringClient.Prompt = "Enter User name";
            string userName = userStringClient.GetUserInput();

            User newUser = new User(userName);
            Users.Add(newUser);
            return newUser;
        }
    }
}
