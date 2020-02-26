using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispensor
{
   abstract class Consumer
    {
        //Attribute
        private string name;
        protected object _Lock = new object();
        // private ConsumerType consumeType;
       
        //Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
   

        //Constructor
        public Consumer(string ConsName, ConsumerType consType)
        {
            Name = ConsName;
          
        }


    

    }
}
