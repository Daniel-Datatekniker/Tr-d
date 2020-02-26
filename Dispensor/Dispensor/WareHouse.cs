using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispensor
{
    class WareHouse
    {
        string name;

        public static Drink[] producedDrinks = new Drink[10];
        public static Soda[] sodas = new Soda[10];
        public static Beer[] beers = new Beer[10];

        public WareHouse()
        {
            name = "Warehouse";
        }
    }
}
