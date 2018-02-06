using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//We are drawing access to the SessionManager class by using it's encapsulating namespace. These are identical to the directory
//hierarchy that has been designed to better seperate elements that are not of interest to one another immediately. Instead, we
//will work to design channels of access to items as we need them by these using statements
using RPG.Engine.Entities.Users;
using RPG.Engine.Entities.Sessions;
//Check out the file hierarchy to see what I mean.
namespace RPG
{
    static class Game
    {
        //A userManager is used to create, load, save, destroy or edit Users
        private static UserManager _userManager;
        private static SessionManager _sessionManager;
        
        //This specifies a path that will always be the same to the top-most level of our UserEnvironment
        public static string DBPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\LoreDB";
        private static void InitializeUserManager()
        {
            //We need a User to run the program...
            //but first we will check to see if we have a persistent file of users available.
            //This is grabbing your own path to your designated desktop on a Windows PC and appends the desired
            //Directory for our purposes.
            Console.WriteLine($"Checking for directory {DBPath}...(Actual process disabled...)");

            //THIS REGION IS REMOVED TO TEST ALL PROCEDURES
            //BEFORE PERSISTENCE. __raSamsara;

            //If this directory does not exist...
            #region DirectoryChecker(DisabledCode)
            //if (!Directory.Exists(DBPath))
            //{
            //    Console.WriteLine($"{DBPath} not found...creating directory...");
            //    //Then we make it exist...
            //    Directory.CreateDirectory(DBPath);
            //}
            #endregion

            Console.WriteLine("Initializing UserManager...");
            //Either way, we still create a new UserManager with the path as it's argument.
            _userManager = new UserManager(DBPath);
            Console.WriteLine("Preparing reference for user...");
            User user;
            Session session;
            _userManager = new UserManager();
            _sessionManager = new SessionManager();

            Console.WriteLine($"Checking for {_userManager.Path}...");
            //Event chaining
            //When a User is Created we want SessionManager
            //to create new Session(User)
            _userManager.UserCreated +=
                _sessionManager.OnUserCreated;

            //DISABLED FOR TESTING WITHOUT FILEPERSISTENCE
            //RE-ENABLE BEFORE RELEASE BUILD.
            //__raSamsara;

            //If that file does exist...
            #region FileChecker(DisabledCode)
            //if (File.Exists(_userManager.Path))
            //{
            //    Console.WriteLine("File found...retrieving users...");
            //    //We retrieve users from the file location
            //    _userManager.Retrieve();
            //    user = _userManager.Select();
            //    //Within our statement we will display a specific message for the user based on whether or not
            //    //this is a return to the system or their first welcome.
            //    Console.WriteLine($"Welcome back, {user.Name}, to Lore.");
            //}
            #endregion

            //this if is temporary and will always yield false
            if (true == false)
            {
                //Unreachable block
            }
            else
            {
                Console.WriteLine("File not found...creating users");
                _userManager.Create();

                //Must remove this call to persistence
                //Re-enable for persistence tests.
                //_userManager.Store();

                user = _userManager.Current;
                session = _sessionManager.Current;
                Console.WriteLine($"Welcome to the Lore {user.Name}");
                Console.WriteLine($"{session.DateTime}");
            }
        }
        //Enter main program...
        static void Main()
        {
            //The Store() of manager classes will not work
            //while testing this stage.
            
            InitializeUserManager();
            //End Game
            Console.ReadLine();
        }
    }
}
