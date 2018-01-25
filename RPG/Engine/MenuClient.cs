using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Engine
{
    //MenuClient<Monster>
    class MenuClient<T>
    {
        public string Prompt { get; set; }
        public List<T> Selections { get; set; }
        public MenuClient()
        {
            Selections = new List<T>();
        }
        public string GetUserInput()
        {
            Console.Write(Prompt + ": ");
            return Console.ReadLine();
        }
        //This method is integral to the app. It allows the user to select a given menu option after being prompted.
        //This method has some problems however. It only allows for string type objects to be returned.
        public T GetUserSelection()
        {
            string promptAppendage = Prompt.EndsWith("?") ? " " : ": ";
            Console.Write(Prompt + promptAppendage);
            int test = Prompt.EndsWith("") ?  1 : 0;
            int horizontalPosition = Console.CursorLeft;
            int verticalPosition = Console.CursorTop;
            int index = 0;
            bool selectionMade = false;
            T selection;
            Console.Write(Selections[index].ToString());
            while (!selectionMade)
            {
                ConsoleKey input =
                    Console.ReadKey().Key;
                if ((input == ConsoleKey.LeftArrow) || (input == ConsoleKey.DownArrow))
                {
                    if (index == 0)
                    {
                        index = Selections.Count - 1;
                    }
                    else
                    {
                        index--;
                    }
                    Console.SetCursorPosition
                    (horizontalPosition,
                        verticalPosition);
                    Console.Write
                    (new string
                        (' ', Console.WindowWidth));
                    Console.SetCursorPosition
                    (horizontalPosition,
                        verticalPosition);
                    //Display new observed selection
                    Console.Write(Selections[index]);
                }
                else if ((input == ConsoleKey.RightArrow) || (input == ConsoleKey.UpArrow))
                {
                    if (index == Selections.Count - 1)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                    Console.SetCursorPosition
                    (horizontalPosition,
                        verticalPosition);
                    Console.Write
                    (new string
                        (' ', Console.WindowWidth));
                    Console.SetCursorPosition
                    (horizontalPosition,
                        verticalPosition);
                    Console.Write(Selections[index]);
                }
                else if (input == ConsoleKey.Enter)
                {
                    break;
                }
            }
            selection = Selections[index];
            Console.Clear();
            return selection;
        }
    }
}
