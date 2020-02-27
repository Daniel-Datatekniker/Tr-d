using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiningPhilophers
{
    class Human
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
        public Human(string _name)
        {
            Name = _name;
        }


        //Methods
        public void Eat()
        {
            lock (this)
            {
                if (true)
                {
                    Monitor.Wait();


                    Monitor.PulseAll();
                }


            }
        }


    }
}
