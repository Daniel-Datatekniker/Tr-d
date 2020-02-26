using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DispenserPart2
{
    class Splitter
    {
        //Attribute
        private string name;

        //Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //Constructor
        public Splitter(string dName)
        {
            Name = name;
        }

        //Methods
        public void Split()
        {
            //Run for ever untill thread is aborted
            while (true)
            {
                //We locking _lock so noone else can use this
                lock (Warehouse._lock)
                {
                    //Checking to see if producer have produced all needed drinks
                    if (Warehouse.producedDrinks.Count != Warehouse.MaxProduction)
                    {
                        //doing illegal stuff here, dont mind me
                        Console.WriteLine("Splitter waiting for production");

                        //Wainting untill someone unlocking our lock
                        Monitor.Wait(Warehouse._lock);


                    }
                    //Checking is our capacity is full
                    else if (Warehouse.sodas.Count == 10 && Warehouse.beers.Count == 10)
                    {
                        //more illegal stuff
                        Console.WriteLine("Splitter waiting drinks to be moved");
                        //Waiting untill someone unlocking the warehouse
                        Monitor.Wait(Warehouse._lock);


                    }
                    else
                    {
                        //doing this untill we have no more left!
                        while (Warehouse.producedDrinks.Count > 0)
                        {
                            //checking it next item is a beer!
                            if (Warehouse.producedDrinks.Peek() is Beer)
                            {
                                //Locking AlcoholicLock, sometimes they need a refill!
                                lock (Warehouse._AlcoholicLock)
                                {
                                    //Removing one beer from productionDrinks adding it to beeer Queue
                                    Warehouse.beers.Enqueue(Warehouse.producedDrinks.Dequeue());
                                    //doing illegal stuff so i can see what im doing
                                    Console.WriteLine("Moving beer");
                                    //to make it look better
                                    Thread.Sleep(500);
                                    //if we produced the max amount we wanted then proceed
                                    if (Warehouse.beers.Count == Warehouse.BeerProduceAmount)
                                    {
                                        //Letting alchoholic know his fresh delivery of beer have arrived
                                        Monitor.PulseAll(Warehouse._AlcoholicLock);
                                    }
                                }
                            }
                            //Checking if next item in produceddrink is soda
                            else if (Warehouse.producedDrinks.Peek() is Soda)
                            {
                                //Locking child out of the soda room
                                lock (Warehouse._ChildLock)
                                {
                                    //Removing 1 soda from produceddrinks and adding it to sodas
                                    Warehouse.sodas.Enqueue(Warehouse.producedDrinks.Dequeue());
                                    //illegal illegal illegal illegal illega illegal
                                    Console.WriteLine("Moving soda");
                                    //Sleeping a little bit
                                    Thread.Sleep(500);
                                    //checking if we produced what we needed
                                    if (Warehouse.sodas.Count == Warehouse.SodaProduceAmount)
                                    {
                                        //Letting the child know that hes soda is arrived and he now can take it
                                        Monitor.PulseAll(Warehouse._ChildLock);
                                    }
                                }
                            }
                        }
                        //Monitor.PulseAll(Warehouse._AlcoholicLock);

                    }
                    Monitor.PulseAll(Warehouse._lock);



                }


            }
        }
    }


}

