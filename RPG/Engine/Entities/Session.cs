using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Engine.Entities.Users;

namespace RPG.Engine.Entities
{
    public class Session : Entity
    {
        private DateTime _dateTime;
        public DateTime DateTime
        {
            get => _dateTime;
            set => _dateTime = value;
        }

        public enum SessionKey
        {
            PlayerSession,
            StoryTellerSession
        }

        public SessionKey SessionType
        {
            get;set;
        }

        public Session() : base() { }

        public Session(User user) : base()
        {
            DateTime = DateTime.Now;
            if(user.Role.GetType() == typeof(Player))
            {
                this.SessionType = SessionKey.PlayerSession;
            }
            else if(user.Role.GetType() == typeof(StoryTeller))
            {
                this.SessionType = SessionKey.StoryTellerSession;
            }
            Console.WriteLine($"Session started by {user.Role} {user.Name} at {this.DateTime}.");
        }
    }
}
