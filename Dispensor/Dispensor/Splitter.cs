using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dispensor
{
    class Splitter
    {
        public object _lock = new object();

        public void Split(object test)
        {
            while (true)
            {
                Monitor.Enter(_lock);
                
                for (int i = 0; i < WareHouse.producedDrinks.Length; i++)
                {
                    if (WareHouse.producedDrinks[i] is Soda)
                    {
                        int firstnull = Array.IndexOf(WareHouse.sodas, null);
                        
                        if (firstnull != -1 && WareHouse.sodas[firstnull] == null )
                        {
                            WareHouse.sodas[firstnull] = (Soda)WareHouse.producedDrinks[i];
                            WareHouse.producedDrinks[i] = null;
                            //JEG VED DET FORKERT
                            Console.WriteLine("i split a soda");
                            Thread.Sleep(1000);
                        }
                    }
                    if (WareHouse.producedDrinks[i] is Beer)
                    {
                        int firstnull = Array.IndexOf(WareHouse.beers, null);
                        if (firstnull != -1 && WareHouse.beers[firstnull] == null)
                        {
                            WareHouse.beers[firstnull] = (Beer)WareHouse.producedDrinks[i];
                            WareHouse.producedDrinks[i] = null;
                            //JEG VED DET FORKERT!
                            Console.WriteLine("i split a beer");
                            Thread.Sleep(1000);
                        }
                    }
                }

                int SodaCount = 0;
                int BeerCount = 0;
                for (int i = 0; i < WareHouse.producedDrinks.Length; i++)
                {
                    if (WareHouse.producedDrinks[i] is Soda)
                    {
                        SodaCount++;
                    }
                    else if (WareHouse.producedDrinks[i] is Beer)
                    {
                        BeerCount++;
                    }
                }

                
                Monitor.Exit(_lock); 
            }
        }



    }
}
