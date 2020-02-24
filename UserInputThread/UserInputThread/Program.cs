using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UserInputThread
{
    class Program
    {
        public static bool T1Alive = false;

        static void Main(string[] args)
        {

            //Creating new object of class user
            User user = new User();
            //Creating new thread with method from user 
            Thread th = new Thread(new ThreadStart(user.Input));
            Thread th2 = new Thread(new ThreadStart(user.Output));

            //Thread nameing
            th.Name = "1";
            th2.Name = "2";
            Thread.CurrentThread.Name = "0";
            //Starting threads
            th.Start();
            T1Alive = true;
            th2.Start();

            //Wait til thread is done
            th.Join();

            Console.WriteLine("Main is done");
        }
    }

    class User
    {
        char userInput = '*';
        char TempChar;
        public void Input()
        {
            while (true)
            {
              
                //Get key from user
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                //Check if key is "Enter

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    userInput = TempChar;
                    Console.WriteLine("\n");
                }
                else
                {
                    //Set tempch to last pressed button (except "enter")
                    TempChar= keyInfo.KeyChar;
                } 
            }
        }

        public void Output()
        {
            while (true)
            {
                Console.Write(userInput);
                Thread.Sleep(40);
            }
        }
    }
}
