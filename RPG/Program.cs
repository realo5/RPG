using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//We are drawing access to the SessionManager class by using it's encapsulating namespace. These are identical to the directory
//hierarchy that has been designed to better seperate elements that are not of interest to one another immediately. Instead, we
//will work to design channels of access to items as we need them by these using statements
using SimpleRPGExample.Engine.Entities;
//Check out the file hierarchy to see what I mean.

namespace SimpleRPGExample
{
    static class Game
    {
        private static SessionManager _sessionManager;

        static void Main()
        {
            InitializeSessionManager();

            Console.ReadLine();
        }

        static void InitializeSessionManager()
        {
            //We will initialize objects in this fashion to better contain specific Entities in seperate manager classes.
            _sessionManager = new SessionManager();
        }
    }
}
