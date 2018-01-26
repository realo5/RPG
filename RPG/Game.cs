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
using RPG.Engine.Entities;
using RPG.Engine.Entities.Users;

//Check out the file hierarchy to see what I mean.

namespace RPG
{
    static class Game
    {
        private static UserManager _userManager;
        public static string DBPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\LoreDB";
        static void Main()
        {
            //We need a User to run the program...
            //but first we will check to see if we have a persistent file of users available.
            //This is grabbing your own path to your designated desktop on a Windows PC and appends the desired
            //Directory for our purposes.
            string dbPath = DBPath;
            //If this directory does not exist...
            if (!Directory.Exists(dbPath))
                //Then we make it exist...
                Directory.CreateDirectory(dbPath);

            _userManager = new UserManager(dbPath);

            //End Game
            Console.ReadLine();
        }

        private static User GetCurrentUser() => _userManager.CurrentUser;
    }
}
