using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DispenserPart2
{
    class Kid : IConsume
    {
        //Attribute
        private string name;

        //Properties
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        //Constructor
        public Kid(string kidName)
        {
            Name = kidName;
        }

        //Methods
        public void RemoveDrink()
        {
            //Doing this forever, you could make something to stop it, but if u want u can abort the thread also
            while (true)
            {
                //Locking our key, not letting other use it before we tell me them too
                lock (Warehouse._ChildLock)
                {
                    //Checking if our warhourse.queue of soda is full or almost full
                    if (Warehouse.sodas.Count <= 9)
                    {
                        /*
                       * IF its not full, then we make him whine about beer lack,
                       * I know it's not allowed to use console writeline inside logic,
                       * i only uise it for debuggin
                       */
                        Console.WriteLine("I have no soda left!");
                        //Waiting for warehouse.ChildLock to be free
                        Monitor.Wait(Warehouse._ChildLock);
                    }
                    else
                    {
                        //Running this untill we hit 0
                        while (Warehouse.sodas.Count > 0)
                        {
                            //Kids need to sleep now at than
                            Thread.Sleep(2000);

                            Console.WriteLine("\ni drank a soada :)\n");
                            //Removing 1 from sodas queue
                            Warehouse.sodas.Dequeue();
                        }
                        //Letting everyone now im doing locking this!
                        Monitor.PulseAll(Warehouse._ChildLock);
                    }
                }
            }
        }
    }
}
