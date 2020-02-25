using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPool_OPG1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prg = new Program();

            Stopwatch myWatch = new Stopwatch();
            myWatch.Start();
            ProcessWithThreadPoolMethod();
            myWatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + myWatch.ElapsedTicks.ToString());
            myWatch.Reset();
            Console.WriteLine("Thread Execution");
            myWatch.Start();
            ProcessWithThreadMethod();
            myWatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + myWatch.ElapsedTicks.ToString());


            //ThreadPool timer = 9433
            //Thread timer = 32038

        }


        static void Process(object ytut)
        {
            if (ytut is string)
            {
                for (int i = 0; i < 100000; i++)
                {
                    Console.WriteLine($"{ytut}");
                    //Ja den bruger så 99 % cpu :(
                    for (int j = 0; j < 100000; j++)
                    {
                        

                    }


                }
               
            }
        }

        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start("Thread");
            }
        }

        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                string test = "hej";
                ThreadPool.QueueUserWorkItem(Process, "thread pool");
            }
        }
    }


    //Skal metoden Process() tage et object som argument, begrund dit svar?


    //Ja for ellers virker threadpool ikke.
}
