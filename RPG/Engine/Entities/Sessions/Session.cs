using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Engine.Entities.Users;

namespace RPG.Engine.Entities.Sessions
{
    //A session should encapsulate everything that a User does.
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

        public Session() : base()
        {
            //How do we get user here?
            DateTime = DateTime.Now;
            //if (user.Role == UserRole.Player)
            //{
            //    this.SessionType = SessionKey.PlayerSession;
            //}
            //else if (user.Role == UserRole.StoryTeller)
            //{
            //    this.SessionType = SessionKey.StoryTellerSession;
            //}
            //SessionOwner = user;
            //Console.WriteLine($"Session started by {user.Role} {user.Name} at {this.DateTime}.");
        }

        public virtual void OnEntityCreated(object source,
            EntityCreatedEventArgs args)
        {
            Type type = args.Entity.GetType();
            string message;
            if (type == typeof(User))
                message = $"Created {type.Name} {args.Entity.ToString()} by {source.ToString()}!";
            else
                throw new Exception("Did not catch User");
            Console.WriteLine(message);
        }
    }
}
