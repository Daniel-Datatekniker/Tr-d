using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispensor
{
    class Beer : Drink
    {
        private int alcProcent;

        public int AlcProcent
        {
            get { return alcProcent; }
            private set { alcProcent = value; }
        }


        public Beer(string dName, int AlcoholProc) : base(dName)
        {
            AlcProcent = AlcoholProc;
        }
    }
}
