using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPGExample.Engine.Entities
{
    internal class SessionManager : EntityManager
    {
        private List<Session> _sessions;
        public List<Session> Sessions { get; }
        protected void CreateSession()
        {
            _sessions.Add(new Session());
        }
    }
}
