using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RPG.Engine.Interfaces;

namespace RPG.Engine.Entities.Users
{
    class UserManager: EntityManager, IName
    {
        private List<User> _users = new List<User>();

        public User CurrentUser
        { get;set; }

        public SeedGenerator SeedGenerator { get; set; }

        public User this[string name]
        {
            get => _users.Find(user => user.Name == name);
        }

        public List<User> Users
        {
            get => _users;
            set => _users = value;
        }

        public UserManager() : base() { }

        public UserManager(string path) : base()
        {
            if (File.Exists(path + @"\Users.xml"))
            {
                RetrieveUsers(path);
                User userSelection = UserSelect();
                UserLogin(userSelection);
            }
            else
                Create();
        }

        private void UserLogin(User userSelection)
        {
            MenuClient<string> stringClient = new MenuClient<string>();
            stringClient.Prompt = "Please login with your password";
            bool passwordValid = false;
            while(passwordValid == false)
            {
                if (stringClient.GetUserInput() != userSelection.Password)
                    Console.WriteLine("Invalid password...");
                else
                {
                    CurrentUser = userSelection;
                    passwordValid = true;
                }
            }
                
        }

        private User UserSelect()
        {
            MenuClient<User> userMenu =
                new MenuClient<User>();
            userMenu.Prompt = "Select a User";
            userMenu.Selections = Users;
            return userMenu.GetUserSelection();
        }

        private void RetrieveUsers(string path)
        {
            string usersPath = path + @"\Users.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));

            using (Stream reader = new FileStream(usersPath, FileMode.Open))
            {
                Users = (List<User>)serializer.Deserialize(reader);
            }
        }

        public override void Create()
        {
            //First we get the user input for a name.
            string userName = AssignName();
            //Then we allow the selection of a role.
            UserRole userRole = AssignUserRole();
            string userPassword = AssignPassword();
            //Then we construct the desired object by passing our arguments to the User constructor.
            User newUser = new User(userName, userRole, userPassword);
            //Adding the new user to a collection of users
            Users.Add(newUser);
            //We assign a newly created user to the CurrentUser property for ease of access.
            CurrentUser = newUser;
            //Otherwise we might have to do Users[indexOfParticularUser] in order to find our required element of the list.
            //Or...which we will do in some occassions, user = Users.Where(u => u.Name == "Somenamewe Arelookingfor");
            //Finally, we write our objects to persistence
            UpdateUsers();
        }
        //This method along with the AssignUserRole were just loose functions in the create method but we have extracted the to 
        //reduce method bloat...which to be honest just makes things hard to read. This keeps things in a very obvious grouping.
        public string AssignName()
        {
            MenuClient<string> userStringClient = new MenuClient<string>();
            userStringClient.Prompt = "Enter User name";
            return userStringClient.GetUserInput();
        }

        public string AssignPassword()
        {
            MenuClient<string> userStringClient = new MenuClient<string>();
            userStringClient.Prompt = "Password";
            bool passwordValid = false;
            string userPassword;
            while(!passwordValid)
            {
                userPassword = userStringClient.GetUserInput();
                if (userPassword.Count() >= 8)
                {
                    passwordValid = true;
                }
                return userPassword;
            }
            throw new Exception("Password Invalid");
        }

        public UserRole AssignUserRole()
        {
            MenuClient<UserRoleKey> userRoleClient = new MenuClient<UserRoleKey>();
            userRoleClient.Prompt = "What shall be your role?";
            foreach (UserRoleKey roleKey in Enum.GetValues(typeof(UserRoleKey)).Cast<UserRoleKey>().ToList<UserRoleKey>())
            {
                userRoleClient.Selections.Add(roleKey);
            }
            return userRoleClient.GetUserSelection() == UserRoleKey.Player ? (UserRole)new Player() : new StoryTeller();
        }

        public override void Create(double seed)
        {
            throw new NotImplementedException();
        }

        private void UpdateUsers()
        {
            XmlSerializer serializer = 
                new XmlSerializer(typeof(List<User>), new Type[] {typeof(User)});
            string usersPath = 
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\LoreDB\Users.xml";
            Console.WriteLine(usersPath);
            StreamWriter writer =
                new StreamWriter(usersPath);
            serializer.Serialize(writer, Users);
        }
    }
}
