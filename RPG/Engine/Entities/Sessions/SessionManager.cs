using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;
using RPG.Engine.Entities.Users;

namespace RPG.Engine.Entities.Sessions
{
    public delegate void NewSessionDelegate(Session session);

    public sealed class SessionManager : EntityManager<Session>, IManage<Session>
    {
        public string SessionsPath
        {
            get; set;
        }
        //We move to the default parameterless constructor for the SessionManager which pulls us out to...
        public SessionManager() : base()
        {
        }

        public SessionManager(string path) : base()
        {
            SessionsPath = path;
        }

        public void Retrieve()
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(List<Session>));
            using (Stream reader = new FileStream(SessionsPath, FileMode.Open))
            {
                Contents = (List<Session>)serializer.Deserialize(reader);
            }
        }

        public void OnSessionCreated()
        {

        }

        public override void Store()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Session>), new Type[] { typeof(User) });
            StreamWriter writer =
                new StreamWriter(SessionsPath);
            serializer.Serialize(writer, Contents);
        }

        public Session Select()
        {
            throw new NotImplementedException();
        }

        public override void Edit()
        {
            throw new NotImplementedException();
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }

        public override void Create()
        {
            throw new NotImplementedException();
        }

        public override void OnCreated(object source)
        {
            throw new NotImplementedException();
        }
    }
}
