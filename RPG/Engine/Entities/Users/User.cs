﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Engine.Entities.Sessions;
using RPG.Engine.Interfaces;

namespace RPG.Engine.Entities.Users
{
    [Serializable]
    public class User : Entity, INameable
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }


        private UserRole _role;
        public UserRole Role
        {
            get { return _role; }
            set { _role = value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string SessionsPath
        {
            get;
            set;
        }

        private SessionManager _sessionManager;

        public User() : base()
        {

        }

        public User(string name, UserRole role, string password) : base()
        {
            //Standard property assignment using the arguments passed in implementation

            Name = name;
            Role = role;
            Password = password;
            ////We need to trigger the creation of a new SessionManager here
            //string sessionsPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\LoreDB\" + $"{Name}Sessions.xml";
            //_sessionManager = new SessionManager(sessionsPath);

            //if (File.Exists(sessionsPath))
            //{
            //    _sessionManager.Retrieve();
            //}
            //else
            //    _sessionManager.Create();
        }

        public override void OnCreated(object source)
        {
            Console.WriteLine(ToString() + " created!");
        }

        public override string ToString() => 
            this.Role + " " + this.Name;
    }
}
