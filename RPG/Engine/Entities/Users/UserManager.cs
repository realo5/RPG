using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Engine.Entities.Users
{
    class UserManager: EntityManager
    {
        private List<User> _users = new List<User>();

        public User CurrentUser
        { get;set; }

        public User this[string name]
        {
            get => _users.Find(user => user.Name == name);
        }

        public List<User> Users
        {
            get => _users;
            set => _users = value;
        }

        public UserManager()
        {
            //...still returning from the Create Method, that is privately accessible only to the UserManager class which means that here
            //upon initialization we will automatically call this(or self in Ruby).Create() and then we are assigning what User is returned
            //from the method to the CurrentUser property for ease of access for outside interaction.
            Create();
        }

        public override void Create()
        {
            //We create a menu client using our own pre-designed tools to make console interaction easier to setup.
            //First we need a userName so we will set the type parameter to string for the generic type object MenuClient<T>
            MenuClient<string> userStringClient = new MenuClient<string>();
            //So in this section below we will just be making method calls to the instance userStringClient
            userStringClient.Prompt = "Enter User name";
            //return the user's input from this method. MenuClient<T>.GetUserInput() is a return method which means that it's result is to be sent out
            //to an assignment, in this case userName.
            string userName = userStringClient.GetUserInput();
            //See UserRole : Entity...
            //Here we allow the user to select what they will be interfacing as...this is where things may throw you but remember much of this is just
            //naming conventions.
            //We could have called UserRoleKey RoleKey or UserRole Role so why so specific if it isn't inheriting from a broader super class like Role
            //or AbstractRole. In this case this object variety will be a property or element of User which means it is a part of it's composition.
            //This is to clearly imply what the object is meant to be a part of. Also, by naming UserRole as we have, now we can be more generic in
            //our element naming within User so that now we can call user.Role which is public UserRole Role {get;set;} instead of user.UserRole.
            //Not nearly as pleasant reading, no?
            MenuClient<UserRoleKey> userRoleClient = new MenuClient<UserRoleKey>();
            userRoleClient.Prompt = "What shall be your role?";
            //Here, if you don't recall from before, we are drawing from an EnumeratedList or Enum of UserRoles that are available in this program.
            //There will likely be more added later for administration purposes but for now: Player and StoryTeller will do us fine.
            //This foreach loop is used to iterate throughout the values of the enum UserRoleKey.
            //loopstatement(Type instance "within" Enum.StaticCall(for a typeof UserRoleKey).then turn it into UserRoleKey.then turn those values
            //into a list to step through.
            foreach (UserRoleKey roleKey in Enum.GetValues(typeof(UserRoleKey)).Cast<UserRoleKey>().ToList<UserRoleKey>())
            {
                userRoleClient.Selections.Add(roleKey);
            }
            UserRole userRole; //Here I am just making it clear that we are using a new instance of userRole soon...but I could have made this one line.
            //This line is a bit of a doozy. This is an example of CSharp's syntactical sugar.
            //Depending on which Key we are return we do one or the other: return a new Player object or a new StoryTeller object
            //Both of which, you'll notice are derived from UserRole.
            userRole = userRoleClient.GetUserSelection() == UserRoleKey.Player ? (UserRole)new Player() : new StoryTeller();
            //Finally we take our required values for a new User and instantiate them here.
            User newUser = new User(userName, userRole);
            //We add this new user to a collection of Users for the manager to maintain if need be(for multiplayer interfacing)
            Users.Add(newUser);
            //And return the User to be consumed.
            CurrentUser = newUser;
        }
    }
}
