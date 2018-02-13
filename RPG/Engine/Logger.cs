using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Engine
{
    public static class Logger
    {
        //A logger should subscribe to all Entities automatically.
        //This is to display all information to Console for 
        //initial testing and then, eventually, to a Debug.Log
        //method for testing in Unity3D.
        // _raSamsara
        private static List<string> _log = new List<string>();
        public static List<string> Log
        {
            get => _log;
            set => _log = value;
        }
        //delegate for calling to Console.Methods and Properties
        //This delegate will behave as a sort of referee for our
        //messages that are being passed to any number of methods
        //within the System.Console namespace.
        //This will have some intelligence to it's decision making to allow for more streamlined logging during the
        //design process.
        public delegate void ConsoleCommandDelegate
            (string message);
        //You will notice, on occasion, several copied methods
        //which you might otherwise expect to yield an error
        //however, on closer inspection: note, the parameter types and number of parameters that are passable to 
        //these methods in question. These are not, in fact- the
        //same method locations being called. But two seperate
        //aliases of similar logic that exist in tandem to be 
        //utilized on a case by case basis depending on what types of arguments you are making to a method.
        //this is known as Method Overloading and can quite
        //useful. Please make note of how this is being defined here and then implemented in the Game object code.
        // _raSamsara;
        public static void LogMessage(string message) => _log.Add(message);
        public static void Print(string message)
        {
            ConsoleCommandDelegate ccDel = DelegateMessage(message);
            ccDel.Invoke(message);
            LogMessage(message);
        }
        public static void Print(string listName, List<string> messages)
        {
            ConsoleCommandDelegate ccDel = Console.WriteLine;
            ccDel(listName);
            LogMessage(listName);
            List<ConsoleCommandDelegate> ccDelList = new List<ConsoleCommandDelegate>();
            for(int i = 0; i < messages.Count;i++)
            {
                ccDelList.Add(new ConsoleCommandDelegate(DelegateMessage(messages[i])));
                ccDelList[i].Invoke(messages[i]);
                LogMessage(messages[i]);
            }
        }
        public static ConsoleCommandDelegate DelegateMessage(string message)
        {
            ConsoleCommandDelegate ccDel;
            char lastCharacter = message.Last<char>();
            if (lastCharacter == '.' || lastCharacter == '!' ||
                lastCharacter == '?' || lastCharacter == ';')
            {
                ccDel = Console.WriteLine;
            }
            else
                ccDel = Console.Write;

            return ccDel;
        }
    }
}
