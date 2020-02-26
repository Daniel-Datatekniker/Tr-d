using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DispenserPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating objects
            Warehouse warehouse = new Warehouse("Næstved varehus");
            Producer producer = new Producer("MeanMachine");
            Splitter splitter = new Splitter("MeanSplitter");
            Alcoholic alcoholic = new Alcoholic("Santa Claus");
            Kid kid = new Kid("Kiddo");

            //Creating threads with methods from difference objects
            Thread th1 = new Thread(producer.ProduceDrinks);
            Thread th2 = new Thread(splitter.Split);
            Thread th3 = new Thread(alcoholic.RemoveDrink);
            Thread th4 = new Thread(kid.RemoveDrink);
            //starting our threads
            th1.Start();
            th2.Start();
            th3.Start();
            th4.Start();

            //Waiting for our thread to finish
            th1.Join();
            th2.Join();
            th3.Join();
            th4.Join();

        }
    }
}
