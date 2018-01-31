using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Engine.Entities
{
    //Any class that is a manager should have this interface mixed in to it's declaration
    interface IManage<TEntity> where TEntity : Entity
    {
        //Make a new Entity
        void Create();
        //Save it
        void Store();
        //Load it
        TEntity Retrieve();
        //Destroy it
        void Destroy();
    }
    //If we have a monster that has the ability to manage other monsters in a similar way we could use an interface much like this as well.
}
