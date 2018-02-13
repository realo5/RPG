using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//We are drawing access to the SessionManager class by using it's encapsulating namespace. These are identical to the directory
//hierarchy that has been designed to better seperate elements that are not of interest to one another immediately. Instead, we
//will work to design channels of access to items as we need them by these using statements
using RPG.Engine;
using RPG.Engine.Entities.Users;
using RPG.Engine.Entities.Sessions;
//Check out the file hierarchy to see what I mean.
namespace RPG
{
    static class Game
    {
        //A userManager is used to create, load, save, destroy or edit Users
        private static UserManager _userManager;
        
        //This specifies a path that will always be the same to the top-most level of our UserEnvironment
        public static string DBPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\LoreDB";
        private static void CheckDB()
        {
            //We need a User to run the program...
            //but first we will check to see if we have a persistent file of users available.
            //This is grabbing your own path to your designated desktop on a Windows PC and appends the desired
            //Directory for our purposes.
            // _raSamsara;
            Logger.Print($"Checking for directory {DBPath}...(Actual process disabled...).");
            string messagesName = "<== Designer Messages ==>";
            List<string> messages = new List<string>();
            for (int i = 0; i <= 5; i++)
            {
                messages.Add($"Test message {i}.");
            }
            Logger.Print(messagesName, messages);
            //If this directory does not exist...
            #region DirectoryChecker(DisabledCode)
            if (!Directory.Exists(DBPath))
            {
                Logger.Print($"{DBPath} not found...creating directory...");
                //Then we make it exist...
                Directory.CreateDirectory(DBPath);
            }
            #endregion
        }
        private static void InitializeUserManager()
        {
            
            Logger.Print("Initializing UserManager...");
            //Either way, we still create a new UserManager with the path as it's argument.
            _userManager = new UserManager(DBPath);
            Logger.Print("Preparing reference for user...");
            User user;
            SessionManager sessionManager = 
                new SessionManager();

            Logger.Print($"Checking for {_userManager.Path}...");
            //Event chaining
            //When a User is Created we want SessionManager
            //to create new Session(User)
            _userManager.UserCreated +=
                sessionManager.OnUserCreated;

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
                Logger.Print("File not found...creating users");
                _userManager.Create();

                //Must remove this call to persistence
                //Re-enable for persistence tests.
                //_userManager.Store();

                user = _userManager.Current;
                //At this point _sessionManager has already
                //responded to _userManager's event being triggered when a new user was born.
                //With this we hand the sessionManager to the 
                //User for proper ownership.
                user.SessionManager = sessionManager;
                Logger.Print($"Welcome to the Lore {user.Name}");

                //And when we need that session info, we can do
                //this...

                //Console.WriteLine($"{user.SessionManager.Current.DateTime}");

                //Or better yet, we make a property that directly retrieves that data from the current
                //property of the SessionManager within the user
                //instance like so:
                Logger.Print(user.CurrentSession.ToString());
                //*Check the User class for the new code.
                //_raSamsara;

                //Here we are attempting to put a User in charge
                //of calling to ActorManager to create a new Actor
                user.CreateNewActor();
                //All entity actions are now being logged so- if
                //we happen to need to later, now we can instantly
                //recall or repeat actions
                user.CurrentSession.Recall(0);
                user.CurrentSession.Repeat(0);
            }
        }
        //Enter main program...
        static void Main()
        {
            //The Store() of manager classes will not work
            //while testing this stage.
            CheckDB();
            InitializeUserManager();
            //End Game
            Console.ReadLine();
        }
    }
}
