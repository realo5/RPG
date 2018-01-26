using System;
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

        static void Main()
        {
            //We need a User to run the program...
            
            //So we will initialize a new user through a manager class.
            _userManager = new UserManager();
            
            //End Game
            Console.ReadLine();
        }

        private static User GetCurrentUser() => _userManager.CurrentUser;
    }
}
