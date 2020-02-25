using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace treadEducation
{
    partial class Program
    {
        int core = Environment.ProcessorCount;
        static int sum = 0;

        static void Main(string[] args)
        {
            Thread[] th = new Thread[1000];

            for (int i = 0; i < th.Length; i++)
            {
                th[i] = new Thread(Addone);
                th[i].Start();
            }


            for (int i = 0; i < th.Length; i++)
            {
                th[i].Join();
            }

            Console.WriteLine(sum);
            Console.ReadKey();
        }

        static void Addone()
        {
           sum++;
            //Interlocked.Add(ref sum);
        }
    }
}
