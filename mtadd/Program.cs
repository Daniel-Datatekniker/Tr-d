using System;
using System.Threading;

class Program
{
    static int sum = 0;

    static void Main()
    {
        Thread[] threads = new Thread[10];

        for (int n = 0; n < threads.Length; n++)
        {
            threads[n] = new Thread(AddOne);
            threads[n].Start();
        }

        for (int n = 0; n < threads.Length; n++)
        {
            threads[n].Join();
        }

        Console.WriteLine(
            "[{0}] sum = {1}",
            Thread.CurrentThread.ManagedThreadId,
            sum
        );
        Console.ReadKey();
    }


    // Buggy version. 
    //Minder om assembler kode
    static void AddOne()
    {
        Console.WriteLine("[{0}] AddOne called",
                          Thread.CurrentThread.ManagedThreadId);
        int temp = sum;
        temp++;
        Thread.Sleep(100);
        sum = temp;
    }

}
