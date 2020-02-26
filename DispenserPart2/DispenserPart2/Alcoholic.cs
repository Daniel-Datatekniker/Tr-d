using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DispenserPart2
{
    class Alcoholic : IConsume
    {
        //Attributes
        private string name;
        //Properties
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        //Constructor
        public Alcoholic(string personName)
        {
            //Setting name from input string
            Name = personName;
        }

        //Removing drink 
        public void RemoveDrink()
        {
            //Doing this forever, you could make something to stop it, but if u want u can abort the thread also
            while (true)
            {
                //Locking our key, not letting other use it before we tell me them too
                lock (Warehouse._AlcoholicLock)
                {
                    //Checking if our warhourse.queue of beers is full or almost full
                    if (Warehouse.beers.Count <= 9)
                    {
                        /*
                         * 
                         * IF its not full, then we make him whine about beer lack,
                         * I know it's not allowed to use console writeline inside logic,
                         * i only uise it for debuggin
                         */
                        Console.WriteLine("I have no beer left!");
                        Monitor.Wait(Warehouse._AlcoholicLock);
                    }
                    else
                    {
                        //Running this until queue is empty
                        while (Warehouse.beers.Count > 0)
                        {
                            //Every great man need a nap now at then
                            Thread.Sleep(3000);
                            //Doing illegal stuff (devil face)
                            Console.WriteLine("i drank a beer...hic!");
                            //Removing beers from the warhourse beeer queue
                            Warehouse.beers.Dequeue();
                        }
                        //Letting everyone know the alchoholic need more beer!
                        Monitor.PulseAll(Warehouse._AlcoholicLock);
                    }
                }
            }
        }
    }
}
