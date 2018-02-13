using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Engine.Entities.Sessions;

namespace RPG.Engine.Interfaces
{
    public interface ISessionable
    {
        SessionManager SessionManager { get; set; }
        Session CurrentSession { get; }
    }
}
