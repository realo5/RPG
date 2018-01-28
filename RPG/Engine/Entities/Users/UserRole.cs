using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RPG.Engine.Entities.Actors;

namespace RPG.Engine.Entities.Users
{
    //We aren't going to use this class, however: it is good to know this...

    //When previously using UserRole as part of the composition of a User
    //we had to do the following to permit serialization...
    //[XmlInclude(typeof(Player))]
    //[XmlInclude(typeof(StoryTeller))]
    //[Serializable]
    //public abstract class UserRole : Entity
    //{
    //    public UserRole()
    //    {

    //    }
    //}

    //When we are finally certain about how we wish to implement the UserRole (either as an enum or a class/struct) then we will dispose of this
    //code.

    //_raSamsara
}
