using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicThreading
{


    class Threprog
    {

        public void WorkThreadFunction()
        {
            //for loop that writing simple thread;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} time to work");
                
            }
        }

    }
    class Program
    {

        static void Main(string[] args)
        {
            //Creating new object of the class Threprog
            Threprog pg = new Threprog();
            //Creating new threads with the method WorkThreadFunction
            Thread th = new Thread(new ThreadStart(pg.WorkThreadFunction));
            Thread th2 = new Thread(new ThreadStart(pg.WorkThreadFunction));
            //Setting the threads name to Thread 1 & 2
            th.Name = "Thread 1";
            th2.Name = "Thread 2";
            //Starting the threads
            th.Start();
            th2.Start();
            //writing what thread we started
            Console.WriteLine($"Starting {th.Name}");
            Console.WriteLine($"Starting {th2.Name}");
            //Waiting for th to finish before ending/Continue main thread
            th.Join();
            //Writing done to see if thread 1 finish before main trhead
            Console.WriteLine("main thread done");
            //Read key to close application
            Console.ReadKey();
        }

    }
}
