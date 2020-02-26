using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispensor
{
    class Soda : Drink
    {
        private string color;

        public string Color
        {
            get { return color; }
            private set { color = value; }
        }

        public Soda(string dName, string dColor) : base(dName)
        {
            color = dColor;
        }
    }
}
