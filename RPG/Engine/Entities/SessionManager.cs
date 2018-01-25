using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Engine.Entities
{
    internal sealed class SessionManager : EntityManager
    {
        private List<Session> _sessions = new List<Session>();
        public List<Session> Sessions
        {
            get => _sessions;
            private set => _sessions = value;
        }
        public SessionManager()/*We shall have a default constructor here that initializes a manager without previous session data*/
    {
            Create(); //In turn by overloading our Create Method we can have variations on what occurs depending on what parameters
            //It calls for and whether or not it is given an argument(s) in implementation.
        }
        //Here we just have the default Create method that requires no parameter
        private void Create()
        {
            Sessions.Add(new Session());
        }
        //Meanwhile, here we might have the same method call tag but argue that there is a path to be considered and...
        public void Create(string path)
        {

        }
    }
}
