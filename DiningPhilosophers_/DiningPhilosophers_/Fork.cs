using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DiningPhilosophers_
{
    class Fork
    {
        public static bool[] fork = new bool[5];

        public void TakeFork(int left,int right)//if the fork is true we wait. if the fork is false we take forks and set them to true.
        {
            lock (this)
            {
                while (fork[left] || fork[right]) 
                {
                    Monitor.Wait(this);
                }
                fork[left] = true;
                fork[right] = true;
            }
        }

        public void PutForkDown(int left,int right)// When we put forks down we set them to false and signals to the other threads
        {
            lock (this)
            {
                fork[left] = false;
                fork[right] = false;
                Monitor.PulseAll(this);
            }
            
        }
    }
}
