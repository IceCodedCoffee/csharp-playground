namespace _15._Async___Async_operations_with_return_values
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
            long result = await CalculateAsync(12, 88);
            Console.WriteLine($"Result: {result}");

            //Task<long> task = CalculateAsync(12, 88);
            //Console.WriteLine("Something else");
            //await task;
            //Console.WriteLine($"Result: {task.Result}");
        }

        static Task<long> CalculateAsync(int x, int y)
        {
            Task<long> task = Task.Run<long>(() =>
            {
                Thread.Sleep(2500);
                return x + y;
            });

            return task;
        }
    }
}