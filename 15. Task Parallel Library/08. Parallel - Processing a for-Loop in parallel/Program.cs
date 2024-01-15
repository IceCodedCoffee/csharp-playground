using System.Diagnostics;

namespace _08._Parallel___Processing_a_for_Loop_in_parallel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] values = [10_000, 100_000, 200_000, 500_000, 1_000_000, 10_000_000];

            for (int i = 0; i < values.Length -1; i++)
            {
                Console.WriteLine("Schleifen: {0}\n{1}", values[i], new string('-', 30));

                Stopwatch watch = new Stopwatch();

                watch.Start();
                ParallelTest(values[i]);
                watch.Stop();

                Console.WriteLine($"Parallel: {watch.ElapsedMilliseconds} ms");
                
                watch.Reset();
                watch.Start();
                SynchronTest(values[i]);
                watch.Stop();

                Console.WriteLine($"Synchron: {watch.ElapsedMilliseconds}ms\n");
            }
        }

        static void SynchronTest(int loops)
        {
            double[] arr = new double[loops];

            for (int i = 0; i < loops; i++)
                arr[i] = Math.Pow(i, 0.333) * Math.Sqrt(Math.Sin(i));
        }

        static void ParallelTest(int loops)
        {
            double[] arr = new double[loops];

            Parallel.For(0, loops, i =>
            {
                arr[i] = Math.Pow(i, 0.333) * Math.Sqrt(Math.Sin(i));
            });
        }
    }
}