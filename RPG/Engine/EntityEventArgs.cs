using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using RPG.Engine.Entities;

namespace RPG.Engine
{
    public class EntityEventArgs : EventArgs
    {
        public MethodInfo Action { get; set; }
        public EntityEventArgs(MethodInfo action)
        {
            Action = action;
        }
    }
}
