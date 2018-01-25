using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//We are drawing access to the SessionManager class by using it's encapsulating namespace. These are identical to the directory
//hierarchy that has been designed to better seperate elements that are not of interest to one another immediately. Instead, we
//will work to design channels of access to items as we need them by these using statements
using RPG.Engine.Entities;
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
            //Go ahead and navigate to Engine/Entities/SessionManager and Session, open those files and let's have a look at
            //what we are doing with Sessions. This is where we will leave our mainMethod for a while as we are going deeper into
            //our call hierarchy to what is contained in the implementation of a SessionManager's constructor.
        }
    }
}
