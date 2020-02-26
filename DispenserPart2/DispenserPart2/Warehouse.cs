using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispenserPart2
{
    class Warehouse
    {
        //Attribute
        private string name;

        //Properties
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
    

        //Making our public queues
        public static Queue<Drink> producedDrinks = new Queue<Drink>();
        public static Queue<Drink> sodas = new Queue<Drink>();
        public static Queue<Drink> beers = new Queue<Drink>();

        //Creating locks
        public static object _lock = new object();
        public static object _AlcoholicLock = new object();
        public static object _ChildLock = new object();

        //Setting oru production limits
        public const int BeerProduceAmount = 10;
        public const int SodaProduceAmount = 10;
        public const int MaxProduction = BeerProduceAmount + SodaProduceAmount;

        //Constructor
        public Warehouse(string WarhouseName)
        {

            Name = WarhouseName;
        }


    }
}
