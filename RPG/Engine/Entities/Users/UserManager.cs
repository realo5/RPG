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

        public UserManager() : base()
        {
            //User manager is built to automatically create a User if it isn't passed a path to a database of users.
            SeedGenerator = new SeedGenerator(DateTime.Now);
        }

        public override void Create()
        {
            //First we get the user input for a name.
            string userName = AssignName();
            //Then we allow the selection of a role.
            UserRole userRole = AssignUserRole();
            //Then we construct the desired object by passing our arguments to the User constructor.
            User newUser = new User(userName, userRole);
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
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\LoreDB\Users";
            Console.WriteLine(usersPath);
            StreamWriter writer =
                new StreamWriter(usersPath);
            serializer.Serialize(writer, Users);
        }
    }
}
