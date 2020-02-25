using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSync
{
    class Program
    {
        static int Sum = 0;
        static object _lock = new object();

        static void Main(string[] args)
        {
            Thread[] threads = new Thread[2];

            
                threads[0] = new Thread(AddTwo);
                threads[0].Start();
            Thread.Sleep(50);
                threads[1] = new Thread(MinusOne);
                threads[1].Start();
             
          
            for (int j = 0; j < threads.Length; j++)
            {
                threads[j].Join();
            }


            Console.WriteLine(Sum);
            Console.ReadKey();
        }

        static void AddTwo()
        {
            while (true)
            {
                Monitor.Enter(_lock);
                Sum += 2;
                Console.WriteLine($"--{Sum}");
                Monitor.Exit(_lock);
                Thread.Sleep(100);
                if (Sum > 100)
                {
                    Thread.CurrentThread.Abort();
                }
            }
        }

        static void MinusOne()
        {
            while (true)
            {
                Monitor.Enter(_lock);
                Sum--;
                Console.WriteLine($"++{Sum}");
                Monitor.Exit(_lock);
                Thread.Sleep(100);
                if (Sum > 100)
                {
                    Thread.CurrentThread.Abort();
                }
            }
        }
    }
}
