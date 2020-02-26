using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dispensor
{
    class Kid : Consumer, IConsume
    {
        public Kid(string ConsName, ConsumerType consType) : base(ConsName, consType)
        {

        }

        public void ConsumeDrink(object test)
        {
            while (true)
            {
                Monitor.Enter(_Lock);
                for (int i = 0; i < WareHouse.producedDrinks.Length; i++)
                {
                    if (WareHouse.producedDrinks[i] != null && WareHouse.producedDrinks[i] is Soda)
                    {
                        WareHouse.sodas[i] = null;
                        Console.WriteLine($"{Name} drank a soda");
                        Thread.Sleep(1000);
                    }
                }
                Monitor.Exit(_Lock); 
            }
        }
    }
}
