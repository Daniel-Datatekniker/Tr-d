using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicThreadingOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main thread";
            //Letting user know we started main thread, for debugging sake
            Console.WriteLine($"{Thread.CurrentThread.Name} is started");
            //Creating object og class thpro
            ThPro pro = new ThPro();
            ThPro pro2 = new ThPro();
            //Creating object of thread with the new thread start that contains a methood called hashtageasy
            //Instead of creating 2 methods, i could give HashTagEasy an object and pass in variables.
            Thread th = new Thread(new ThreadStart(pro.HashTagEasy));
            Thread th2 = new Thread(new ThreadStart(pro2.Easy));
            //Naming the trhead
            th.Name = "thread 1";
            th2.Name = "thread 2";
            //Starting the thread
            th.Start();
            th2.Start();
            //Waiting for the thread to end
            th.Join();
            th2.Join();
            //Testing to see if thread 1 finish before main thread
            Console.WriteLine($"{Thread.CurrentThread.Name} is done");

        }
    }


    class ThPro
    {
        public void HashTagEasy()
        {

            //Making a for loop writing 5x times
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($" C#-Threading is easy {Thread.CurrentThread.Name} is running");
                //Waiting 1 min
                Thread.Sleep(1000);

                //Is it smart to use sleep?

                //Well it depends, if you depend on thread 1 to finish before thread 2,
                //maybe is not that great, because while 1 is sleeping 2 will do
                //his work first
                //You can use the priority to get 1 thread to finish faster than the other
            }

        }

        public void Easy()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Even with more threads ... {Thread.CurrentThread.Name} is running");
                Thread.Sleep(1000);
            }
        }

    }
}
