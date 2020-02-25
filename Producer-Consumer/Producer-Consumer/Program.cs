using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Producer_Consumer
{
    class Program
    {
        //creating my buffer on 10 pieces of steel
        static Steel[] buffer = new Steel[10];
        //Creating a locker object
        static object _locker = new object();

        static void Main(string[] args)
        {
            //Creating 2 new thread, that run method producer and consumer
            Thread th1 = new Thread(Producer);
            Thread th2 = new Thread(Consumer);

            //Starting those 2 threads
            th1.Start();
            th2.Start();

            //Waiting for thread 1 to be finish before moving on
            th1.Join();

            

            Console.ReadKey();
        }


        static void Consumer(object txt)
        {
            while (true)
            {
                //Creating a lock so other thread waits
                Monitor.Enter(_locker);
                //Creating a random
                Random random = new Random();
                //Making for loop with ran numbers
                for (int i = 0; i < random.Next(1, buffer.Length); i++)
                {
                    //checking if buffer is not null    
                    if (buffer[i] != null)
                    {
                        
                        Console.WriteLine("I bough a steel");
                        //removing steel from my buffer
                        buffer[i] = null;
                        //Taking a nap
                        Thread.Sleep(1000);
                    }
                }

             //Releaseing the lock
                Monitor.Exit(_locker);
            }
        }

        static Steel te()
        {
            return new Steel();
        }

        static void Producer(object txt)
        {
            while (true)
            {
                Monitor.Enter(_locker);
                int count = 0;
                for (int i = 0; i < buffer.Length; i++)
                {
                    if (buffer[i] == null)
                    {
                        buffer[i] = new Steel();
                        count++;

                    }

                   
                }
                if (count > 0)
                {
                    Console.WriteLine($"i am making {count} steel");

                    for (int i = 0; i < count; i++)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("I made 1 new steel");
                    }

                }
                Monitor.Exit(_locker);
            }
        }
    }


}
