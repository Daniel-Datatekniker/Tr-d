using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dispensor
{
    class Producer
    {
        //Attributes
        private string name;
        object _lock = new object();
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
            for (int i = 0; i < WareHouse.producedDrinks.Length; i++)
            {
                for (int j = 0; j < WareHouse.producedDrinks.Length / 2; j++)
                {
                    WareHouse.producedDrinks[j] = new Soda("Fanta", "Orange");
                }
                for (int k = WareHouse.producedDrinks.Length / 2; k < WareHouse.producedDrinks.Length; k++)
                {
                    WareHouse.producedDrinks[k] = new Beer("KongStrong", 50);
                }
            }
        }


        public void ProduceDrinks(object test)
        {
            while (true)
            {
                Monitor.Enter(_lock);
                for (int i = 0; i < WareHouse.producedDrinks.Length; i++)
                {

                    for (int j = 0; j < WareHouse.producedDrinks.Length / 2; j++)
                    {
                        if (WareHouse.producedDrinks[j] == null)
                        {
                            WareHouse.producedDrinks[j] = new Soda("Fanta", "Orange");
                            Console.WriteLine("I produces a fanta organge");
                            Thread.Sleep(100);
                        }
                    }
                    for (int k = WareHouse.producedDrinks.Length / 2; k < WareHouse.producedDrinks.Length; k++)
                    {
                        if (WareHouse.producedDrinks[k] == null)
                        {
                            WareHouse.producedDrinks[k] = new Beer("KongStrong", 50);
                            Console.WriteLine("I produce a beer");
                            Thread.Sleep(100);
                        }
                    }
                }
                Monitor.Exit(_lock); 
            }
        }



    }
}
