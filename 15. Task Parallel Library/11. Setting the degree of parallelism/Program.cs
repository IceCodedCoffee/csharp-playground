using System.Diagnostics;

namespace _11._Setting_the_degree_of_parallelism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };
            double[] arr = new double[100_000_000];
            int currentIteration = 0;
            Stopwatch watch = new Stopwatch();

            watch.Start();

            Parallel.For(0, arr.Length, options, i=>
            {
                currentIteration = i;
                arr[i] = Math.Pow(i, 0.333) * Math.Sqrt(Math.Sin(i));
            });

            watch.Stop();
            Console.WriteLine($"ProcessorCount = {Environment.ProcessorCount}, Parallel: {watch.ElapsedMilliseconds} ms");
        }
    }
}