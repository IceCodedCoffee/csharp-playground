using System.Diagnostics;

namespace _10._Parallel___Cancelling_a_parallel_for_loop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] arr = new double[100_000];
            int currentIteration = 0;
            Stopwatch watch = new Stopwatch();

            watch.Start();

            Parallel.For(0, arr.Length, (i, option) =>
            {
                currentIteration = i;
                arr[i] = Math.Pow(i, 0.333) * Math.Sqrt(Math.Sin(i));

                if (i > 1000)
                    option.Stop();
            });

            watch.Stop();
            Console.WriteLine($"Iteration: {currentIteration}, Parallel: {watch.ElapsedMilliseconds} ms");
        }
    }
}