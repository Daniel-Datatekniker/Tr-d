using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dispensor
{
    class Program
    {
      

        static void Main(string[] args)
        {
            WareHouse wareHouse = new WareHouse();
            Producer producer = new Producer("MeanMachine");
            Splitter splitter = new Splitter();
            Kid kid = new Kid("KID", ConsumerType.kid);
            Alcholic alcholic = new Alcholic("Alcholic", ConsumerType.alcoholic);


            ThreadPool.QueueUserWorkItem(producer.ProduceDrinks);
            ThreadPool.QueueUserWorkItem(splitter.Split);
            ThreadPool.QueueUserWorkItem(kid.ConsumeDrink);
            ThreadPool.QueueUserWorkItem(alcholic.ConsumeDrink);



            Console.ReadLine();
        }
    }
}
