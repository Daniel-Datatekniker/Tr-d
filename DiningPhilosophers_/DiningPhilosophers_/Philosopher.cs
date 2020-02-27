using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DiningPhilosophers_
{
    class Philosopher
    {
        private int PhilosophNr; //used to keep track of philosophers
        private int Left { get; set; }
        private int Right { get; set; }
        private Fork Fork;
        Random rnd = new Random();

        
        public Philosopher(int philosoph, Fork fork) //If dealing with the last philosopher(in this case the fifth), set the left fork's
                                                     //value to that of the first index in the fork array
        {
            if (philosoph == 5)
            {
                Left = 0;
            }
            else
            {
                Left = philosoph;
            }
            Right = philosoph - 1;
            PhilosophNr = philosoph;
            Fork = fork;
            
        }

        public void Run()//Calls the TakeFork method and sleeps for a random time. Calls the PutForkDown method and sleeps for a random time.
        {
            while (true)
            {
                Thread.Sleep(rnd.Next(2000, 3000));
                Console.WriteLine("Philosopher {0} is thinking", PhilosophNr);
                Fork.TakeFork(Left, Right);
                Console.WriteLine("Philosopher {0} is eating", PhilosophNr);
                Thread.Sleep(rnd.Next(2000,3000));
                Fork.PutForkDown(Left, Right);
                Console.WriteLine("Philosopher {0} is waiting", PhilosophNr);

            }
        }
    }
}
