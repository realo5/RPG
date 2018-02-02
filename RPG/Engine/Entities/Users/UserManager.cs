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
    class UserManager : EntityManager<User>, IManage<User>
    {
        private string _path;
        public override string Path
        {
            get { return _path; }
            set
            {
                _path = value + @"\Users.xml";
            }
        }

        public SeedGenerator SeedGenerator { get; set; }

        public UserManager() : base() { }

        //Here the userManager recieves a path to check if the Users.xml file exists within the
        //LoreDB directory
        public UserManager(string path) : base(path)
        {
            
        }

        #region PublicInterface
        public override void Create()
        {
            MenuClient<string> userNameClient = new MenuClient<string>();
            userNameClient.Prompt = "User name";
            string userName = userNameClient.GetUserInput();
            MenuClient<UserRole> userRoleClient = new MenuClient<UserRole>();
            userRoleClient.Prompt = "What is your role?";
            foreach (UserRole role in Enum.GetValues(typeof(UserRole)).Cast<UserRole>().ToList<UserRole>())
            {
                userRoleClient.Selections.Add(role);
            }
            UserRole userRole = userRoleClient.GetUserSelection();
            MenuClient<string> userPasswordClient = new MenuClient<string>()
            {
                Prompt = "Password"
            };
            string userPassword = userPasswordClient.GetUserInput();
            User newUser = new User(userName, userRole, userPassword);
            Contents.Add(newUser);
            Current = newUser;
        }
        public override void Store()
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(List<User>), new Type[] { typeof(User) });
            string usersPath =
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\LoreDB\Users.xml";
            Console.WriteLine(usersPath);
            StreamWriter writer =
                new StreamWriter(usersPath);
            serializer.Serialize(writer, Contents);
        }
        public User Select()
        {
            //We create an instance of our own MenuClient<T> object that I've enabled for use
            //Any object may be assigned to the MenuClientConstructer call like this.
            MenuClient<User> userMenu =
                new MenuClient<User>();
            userMenu.Prompt = "Select a User";
            userMenu.Selections = Contents;
            return userMenu.GetUserSelection();
        }
        public void Retrieve()
        {
            //This accesses a serializer to create xml files from objects
            //in this case from a list of User objects.
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
            //This creates a subsection that creates a using for a Stream object.
            //Note that we send the FileStream constructor the usersPath as an argument
            //The Enum FileMode is available to select options of how to interact with system
            //files. You should now be able to see a bit clearer the way that we have used
            //some of the objects that we've been creating here like the designers of the .NET
            //framework have built tools for us to use within itself.
            using (Stream reader = new FileStream(Path, FileMode.Open))
            {
                //Here we assign the return references of Users within a List from a reader
                //object that has been assigned the users path as seen above.
                Contents = (List<User>)serializer.Deserialize(reader);
            }
        }
        public override void Edit()
        {
            //First we get the user input for a name.
            string userName = AssignName();
            //Then we allow the selection of a role.
            UserRole userRole = AssignUserRole();
            string userPassword = AssignPassword();
            //Then we construct the desired object by passing our arguments to the User constructor.
            Current = new User(userName, userRole, userPassword);
        }
        public void Destroy()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region PrivateFunctions
        private void UserLogin(User userSelection)
        {
            MenuClient<string> stringClient = new MenuClient<string>();
            stringClient.Prompt = "Please login with your password";
            bool passwordValid = false;
            //Here we enter a while loop until a valid password is entered
            while(passwordValid == false)
            {
                //This is checking against the stringClient's method for receiving user input
                //If that return value is not equal to the password of the userSelection that
                //was passed into the method from the posterior method.
                if (stringClient.GetUserInput() != userSelection.Password)
                    //We tell you that you entered the wrong password.
                    Console.WriteLine("Invalid password...");
                else
                {
                    //Otherwise, the only alternative is that your entry is == userSelection.Password
                    //then we assign your selection to the CurrentUser Property of the UserManager
                    Current = userSelection;
                    //and your password was true after all so...
                    passwordValid = true;
                }
            }   
        }

        //This method along with the AssignUserRole were just loose functions in the create method but we have extracted the to 
        //reduce method bloat...which to be honest just makes things hard to read. This keeps things in a very obvious grouping.
        private string AssignName()
        {
            MenuClient<string> userStringClient = new MenuClient<string>();
            userStringClient.Prompt = "Enter User name";
            return userStringClient.GetUserInput();
        }

        private string AssignPassword()
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

        private UserRole AssignUserRole()
        {
            MenuClient<UserRole> userRoleClient = new MenuClient<UserRole>();
            userRoleClient.Prompt = "What shall be your role?";
            foreach (UserRole roleKey in Enum.GetValues(typeof(UserRole)).Cast<UserRole>().ToList<UserRole>())
            {
                userRoleClient.Selections.Add(roleKey);
            }
            return userRoleClient.GetUserSelection();
        }

        public override void OnCreated(object source)
        {
            Console.WriteLine(Current.Name + " created!");
        }

        #endregion

    }
}
