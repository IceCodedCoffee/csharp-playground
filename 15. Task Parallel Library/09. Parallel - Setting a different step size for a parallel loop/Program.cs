namespace _09._Parallel___Setting_a_different_step_size_for_a_parallel_loop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parallel.For(0, 50, i =>
            {
                int newIndex = i * 2;
                Console.Write($" {newIndex} ");
            });
        }
    }
}