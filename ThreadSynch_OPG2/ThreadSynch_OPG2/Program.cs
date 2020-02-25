using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSynch_OPG2
{
    class Program
    {
        static string output = "";
        static int count = 0;
        static object _lock = new object();
        static void Main(string[] args)
        {
            //Creating array of threads
            Thread[] Threads = new Thread[2];

            

            //Want to run this 4 times
            for (int i = 0; i < 100; i++)
            {
                //Creating new threads that run methods
                Threads[0] = new Thread(Star);
                Threads[1] = new Thread(HashTag);

                //Starting the threads
                Threads[0].Start();
                Threads[1].Start();

                //Waiting for them to finish before moving on
                for (int j = 0; j < Threads.Length; j++)
                {
                    Threads[j].Join();
                }
                // Thread.Sleep(100);
            }

            //Dont want program to exit 
            Console.ReadKey();

        }

        static void Star()
        {
            //Locking output and making other threads wait
            Monitor.Enter(_lock);
            //running 60 times
            for (int i = 0; i < 60; i++)
            {
                //Change the output string
                output = "*";
                //Writing out the output
                Console.Write(output);
                //Increasing my counter with 1
                count++;
            }
            //Printing out my count
            Console.Write(count);
            //Making new line
            Console.WriteLine("\n");
            //Releasing my lock, let other thread access output¨,
            Monitor.Exit(_lock);
        }

        //Same happend as method above.
        static void HashTag()
        {
            Monitor.Enter(_lock);
            for (int i = 0; i < 60; i++)
            {
                output = "#";
                Console.Write(output);
                count++;
            }
            Console.Write(count);
            Console.WriteLine("\n");
            Monitor.Exit(_lock);
        }



    }
}
