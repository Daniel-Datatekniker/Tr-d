using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DispenserPart2
{
    class Producer
    {
        //Attributes
        private string name;


        //Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        //Constructor
        public Producer(string nam)
        {
            Name = nam;
        }


        //Methods
        public void ProduceDrinks(object test)
        {
            //Running this forever
            while (true)
            {
                //Locking the lock so no one can use it
                lock (Warehouse._lock)
                {
                    //checking if we already produced max production 
                    if (Warehouse.producedDrinks.Count >= Warehouse.MaxProduction)
                    {
                        //doing illegalstuff so i can see in blind
                        Console.WriteLine("Producer Waiting for splitter");
                        //Waiting someone to tells us to check if production is needed
                        Monitor.Wait(Warehouse._lock);
                    }
                    //2 counters
                    int beerCount = 0;
                    int sodaCount = 0;
                    //checking how many of each we have in stock
                    if (Warehouse.producedDrinks.Count > 0)
                    {
                        foreach (Drink drink in Warehouse.producedDrinks)
                        {
                            if (drink is Soda)
                            {
                                sodaCount++;
                            }
                            else if (drink is Beer)
                            {
                                beerCount++;
                            }
                        }
                    }

                    //If we have less bear than we warehouse stock  than do this
                    if (beerCount < Warehouse.BeerProduceAmount)
                    {
                        //checking how many we need and adding so many 
                        //Same we do for soda down uynder
                        for (int i = 0; i < Warehouse.BeerProduceAmount - beerCount; i++)
                        {
                            //adding new beers
                            Warehouse.producedDrinks.Enqueue(new Beer("Mon", 13));
                            //illegal stuff so i dont work in blind
                            Console.WriteLine("producing beer");
                            //Sleeping a little 
                            Thread.Sleep(500);
                        }
                    }
                    if (sodaCount < Warehouse.SodaProduceAmount)
                    {
                        for (int i = 0; i < Warehouse.SodaProduceAmount - sodaCount; i++)
                        {
                            Warehouse.producedDrinks.Enqueue(new Soda("Fanta", "Orange"));
                            Console.WriteLine("Producing fanta");
                            Thread.Sleep(500);
                        }
                    }

                    //Relasing the lock and telling everyone that we released the lock
                    Monitor.PulseAll(Warehouse._lock);
                }


            }

        }


    }
}
