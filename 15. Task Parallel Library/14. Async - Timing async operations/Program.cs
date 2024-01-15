namespace _14._Async___Timing_async_operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start();
            Console.WriteLine("End of Main ...");
            Console.ReadLine();
        }

        static async void Start()
        {
            Task task = DoSomethingAsync(1);
            Console.WriteLine("after calling DoSomething(1) ...");
            await task;
            Console.WriteLine("Async operation finished");
        }

        static Task DoSomethingAsync(int id)
        {
            Task task = Task.Run(() =>
            {
                Console.WriteLine($"Operation {id} commences ...");
                Thread.Sleep(2500);
                Console.WriteLine($"Operation {id} is finished.");
            });

            return task;
        }
    }
}