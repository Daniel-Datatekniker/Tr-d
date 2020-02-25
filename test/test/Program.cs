using System;
using System.Threading;

namespace Threading
{
    public class Assignment4
    {
        private char _ch = '*';
        public Assignment4()
        {
            //Create printer Thread
            Thread printer = new Thread(DisplayChar);
            printer.Name = "Printer Thread";
            printer.Start();

            //Create listener Thread
            Thread listener = new Thread(ListenForKeyInput);
            listener.Name = "Listener Thread";
            listener.Priority = ThreadPriority.Highest;
            listener.Start();
        }

        //This method checks if "enter" key is pressed and changes the ch variable to the last pressed button (except "enter")
        private void ListenForKeyInput()
        {
            char tempch = _ch;
            while (true)
            {
                //Get key from user
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                //Check if key is "Enter"
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    _ch = tempch;
                    Console.WriteLine("\n");
                }
                else
                {
                    //Set tempch to last pressed button (except "enter")
                    tempch = keyInfo.KeyChar;
                }
            }
        }

        //This method prints the _ch attribute all the time.
        private void DisplayChar()
        {
            while (true)
            {
                Console.Write(_ch);
            }
        }
    }
}
