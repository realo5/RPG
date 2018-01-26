using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Engine.Entities
{
    public sealed class SessionManager : EntityManager
    {
        //This will highlight because it is a field with a default value assigned to it. So this happens right at initialization and then...
        private List<Session> _sessions = new List<Session>();
        
        public List<Session> Sessions
        {
            get => _sessions;
            private set => _sessions = value;
        }

        public Session CurrentSession { get; set; }
        //We move to the default parameterless constructor for the SessionManager which pulls us out to...
        public SessionManager() : base()
        { 

        }
        //Here we just have the default Create method that requires no parameter
        public override void Create()
        {
            //This is Create as it would have been called from Entity's constructor but her is implemented as a specific Create() method as per the class with the following code...
            //First, creating a new session instance
            Session newSession = new Session();
            Sessions.Add(newSession);
            CurrentSession = newSession;
        }
        //Meanwhile, here we might have the same method call tag but argue that there is a path to be considered and...
        public void Create(string path)
        {

        }

        public override void Create(double seed)
        {
            throw new NotImplementedException();
        }
    }
}
