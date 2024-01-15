namespace _13._Async___Declaring_an_async_method
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
            await DoSomethingAsync(1);
            Console.WriteLine("after calling DoSomething(1) ...");
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