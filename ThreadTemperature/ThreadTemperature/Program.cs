using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTemperature
{


    class Program
    {
        public static int Temperature = 0;
        public static int Alarms = 0;

        static void Main(string[] args)
        {
            //Naming main thread for debugging sake
            Thread.CurrentThread.Name = "Main";
            //telling that main is running debugging sake
            Console.WriteLine($"{Thread.CurrentThread.Name} is running");
            //Creating new object of class temp
            Temp tp = new Temp();
            //Creating new object of thread with running method tp.tempchanger;
            Thread thChanger = new Thread(new ThreadStart(tp.TempChanger));
            //Giving thread a name
            thChanger.Name = "1";
            //Setting priority
            thChanger.Priority = ThreadPriority.Normal;
            //Starting thread
            thChanger.Start();
            //Waiting for thread to finish
            thChanger.Join();
            //Writeline
            Console.WriteLine("Main thread continues");

            Console.ReadKey();
        }
    }


    class Temp
    {


        public void TempChanger()
        {
            //Running until aborting
            while (true)
            {
                Random ran = new Random();
                //Sleep 2 sec
                Thread.Sleep(2000);
                //Getting random temp
                Program.Temperature = ran.Next(-20, 120);
                //Writing out the current temp
                Console.WriteLine($"New temperature {Program.Temperature}");

                //Checking temp and outputting new tmep
                if (Program.Temperature < 0)
                {
                    Console.WriteLine($"Warning the temp is under 0 decrease\nCurrent temperature = {Program.Temperature}");
                    Program.Alarms++;
                }
                else if (Program.Temperature > 100)
                {
                    Console.WriteLine($"Warning the temp is above 100 decrease\nCurrent temperature = {Program.Temperature}");
                    Program.Alarms++;
                }

                if (Program.Alarms > 2)
                {
                    Console.WriteLine("This shit is too unstable, im aborting!!");
                    Thread.CurrentThread.Abort();
                }
            }

        }


    }
}
