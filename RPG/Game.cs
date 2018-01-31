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
using RPG.Engine.Entities.Items;

//Check out the file hierarchy to see what I mean.

namespace RPG
{
    static class Game
    {
        //A userManager is used to create, load, save, destroy or edit Users
        private static UserManager _userManager;
        //This specifies a path that will always be the same to the top-most level of our UserEnvironment
        public static string DBPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\LoreDB";
        //Enter main program...
        static void Main()
        {
            //We need a User to run the program...
            //but first we will check to see if we have a persistent file of users available.
            //This is grabbing your own path to your designated desktop on a Windows PC and appends the desired
            //Directory for our purposes.
            //If this directory does not exist...
            if (!Directory.Exists(DBPath))
                //Then we make it exist...
                Directory.CreateDirectory(DBPath);
            //Either way, we still create a new UserManager with the path as it's argument.
            _userManager = new UserManager(DBPath);
            
            //End Game
            Console.ReadLine();
        }
        //This is just so we don't have to type _userManager.CurrentUser in order to return it's value.
        //It is much more elegant to type GetCurrentUser()
        private static User GetCurrentUser() => _userManager.CurrentUser;
    }
}
