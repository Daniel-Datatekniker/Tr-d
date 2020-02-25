using System;
using System.Diagnostics;
using System.Threading;

class Program1
{
    static void Main()
    {
        // Determine how many cores/processors there are on this machine.
        //
        int coreCount = Environment.ProcessorCount;

        Console.WriteLine("*********************************");
        Console.WriteLine("Process/core count = {0}", coreCount);

        // Get some data to work with.
        //
        double[] data = GetData();

        Stopwatch sw = Stopwatch.StartNew();

        // Process the entire data set using one thread
        // for comparison purposes.
        //
        ArrayProcessor wholeArray = new ArrayProcessor(data, 0, data.Length - 1);
        wholeArray.ComputeSum();
        sw.Stop();

        Console.WriteLine(
            "1 thread computed {0:n0} in {1:n0} ms",
            wholeArray.Sum, sw.ElapsedMilliseconds
        );

        Console.ReadKey();
    }

    static double[] GetData()
    {
        double[] data = new double[50000];

        for (int n = 0; n < data.Length; n++)
        {
            data[n] = n;
        }

        return (data);
    }
}
