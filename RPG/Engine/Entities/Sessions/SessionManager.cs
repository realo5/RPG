using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;
using RPG.Engine.Entities.Users;
using RPG.Engine.Interfaces;

namespace RPG.Engine.Entities.Sessions
{
    public sealed class SessionManager : EntityManager<Session>, IManage<Session>
    {
        public string SessionsPath
        {
            get; set;
        }

        public event EntityCreatedEventHandler SessionCreated;

        //We move to the default parameterless constructor for the SessionManager which pulls us out to...
        public SessionManager() : base()
        {
            //when an ISessionable entity is created
            //We must call our OnISessionable()

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

        public void OnUserCreated(object source, EntityCreatedEventArgs args)
        {
            Create(args);
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

        public void Create(EntityCreatedEventArgs args)
        {
            Session newSession = new Session(args);
            Current = newSession;
            Contents.Add(newSession);
            //OnCreated(newSession);
        }

        public void OnUserCreated()
        {

        }

        //public void OnEntityCreated(object source, EntityCreatedEventArgs args)
        //{
        //    if (args.Entity.GetType() == typeof(ISessionable))
        //        this.Create(args);
        //}
    }
}
