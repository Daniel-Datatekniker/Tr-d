using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispenserPart2
{
    class Drink
    {
        private string name;


        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public Drink(string dName)
        {
            Name = dName;

        }
    }
}
