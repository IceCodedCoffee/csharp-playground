namespace _02._Tasks_with_return_value
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<string> task = Task.Run(() =>
            {
                Thread.Sleep(3000);
                return DateTime.Now.ToLongTimeString();
            });

            Console.WriteLine("Task still running ...");

            Console.WriteLine($"Result: {task.Result}");

            Console.WriteLine("Task finished ...");

            Console.WriteLine();
        }
    }
}