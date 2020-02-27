using System;
using System.Security.Cryptography;
using System.Threading;

namespace DiningPhilosophers_
{
    class Program
    {
        static void Main(string[] args)
        {
           Fork fork = new Fork();

           Philosopher p1 = new Philosopher(1,fork);
           Philosopher p2 = new Philosopher(2,fork);
           Philosopher p3 = new Philosopher(3,fork);
           Philosopher p4 = new Philosopher(4,fork);
           Philosopher p5 = new Philosopher(5,fork);
           
           Thread thread1 = new Thread(p1.Run);
           Thread thread2 = new Thread(p2.Run);
           Thread thread3 = new Thread(p3.Run);
           Thread thread4 = new Thread(p4.Run);
           Thread thread5 = new Thread(p5.Run);

           thread1.Start();
           thread2.Start();
           thread3.Start();
           thread4.Start();
           thread5.Start();
        }
    }
}
