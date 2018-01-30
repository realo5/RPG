using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Engine.Entities;
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

        private SessionManager _sessionManager;
        public Session CurrentSession
        {
            get; set;
        }
        string INameable.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public User() : base()
        {

        }

        public User(string name, UserRole role, string password) : base()
        {
            //Standard property assignement using the arguments passed in implementation
            Name = name;
            Role = role;
            Password = password;
            _sessionManager = new SessionManager(this);
            
        }

        public override string ToString() => this.Role + this.Name;
    }
}
