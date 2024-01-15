namespace _12._Parallel___Processing_a_foreach_loop_in_parallel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] namen = { "Peter", "Uwe", "Udo", "Willi", "Pia", "Michael", "Conie" };

            Parallel.ForEach(namen, name =>
            {
                Console.WriteLine(name);
            });
        }
    }
}