using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace wait
{
    class Program
    {
        static Queue<testobject> testobjects = new Queue<testobject>();
        static object _lock = new object();
        static void Main(string[] args)
        {
            Thread th = new Thread(Produce);
            Thread th1 = new Thread(Remove);
            Thread th3 = new Thread(Remove2);

            th.Start();
            th1.Start();
            th3.Start();


            th.Join();

        }

        static void Produce()
        {
            while (true)
            {
                lock (_lock)
                {
                    while (testobjects.Count > 5)
                    {

                        Console.WriteLine("Im waiting");
                        Monitor.Wait(_lock);
                    }



                    for (int i = 0; i < 5; i++)
                    {
                        testobjects.Enqueue(new testobject());
                        Console.WriteLine(testobjects.Count + " Enqueue");
                        Thread.Sleep(1000);


                    }

                    Monitor.PulseAll(_lock);


                }
            }

        }

        static void Remove()
        {
            while (true)
            {
                lock (_lock)
                {

                    Console.WriteLine("Remover waiting for producer");
                    Monitor.Wait(_lock);


                    for (int i = 0; i < 5; i++)
                    {
                        testobjects.Dequeue();
                        Thread.Sleep(1000);
                        Console.WriteLine("Remover 1 removed 1");
                    }
                    Monitor.PulseAll(_lock);

                }
            }
        }
        static void Remove2()
        {
            while (true)
            {

                lock (_lock)
                {

                    Console.WriteLine("Remover 2 waiting for producer");
                    Monitor.Wait(_lock);

                    for (int i = 0; i < 5; i++)
                    {
                        testobjects.Dequeue();
                        Thread.Sleep(1000);
                        Console.WriteLine("Remover 2 removed 1");
                    }
                    Monitor.PulseAll(_lock);
                }
            }
        }
    }

}



