﻿using System;
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
        public User Publisher { get; set; }

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

        }

        public Session(EntityCreatedEventArgs args)
        {
            //How do we get user here?
            DateTime = DateTime.Now;
            Console.WriteLine
                (args.Entity.ToString() + " created by " +
                this.ToString() + "!");

        }

        //public virtual void OnCreated(object source,
        //    EntityCreatedEventArgs args)
        //{
        //    Type type = args.Entity.GetType();
        //    string message;
        //    if (type == typeof(User))
        //        message = $"Created {type.Name} {args.Entity.ToString()} by {source.ToString()}!";
        //    else
        //        throw new Exception("Did not catch User");
        //    Console.WriteLine(message);
        //}
    }
}
