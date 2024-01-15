namespace _05._Cancelling_a_task_from_outside
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            var task = Task.Run(() =>
            {
                while (true)
                {
                    Console.Write("X");

                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("\nCancelling the task");
                        token.ThrowIfCancellationRequested();
                    }
                }
            }, token);

            try
            {
                Thread.Sleep(2000);
                cts.Cancel();
                task.Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var item in ex.InnerExceptions)
                    Console.WriteLine($"{ex.Message} - {item.Message}");
            }
            Console.WriteLine();

            // ----------------------------------------------------------------------------------------------

            Console.WriteLine("Press the space bar to cancel the task ...");
            CancellationTokenSource cts2 = new CancellationTokenSource();
            CancellationToken token2 = cts2.Token;


            token2.Register(() =>
            {
                Console.WriteLine("Task was cancelled!");
            });


            var task2 = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"Number: {i}");
                    Thread.Sleep(500);
                    if (token2.IsCancellationRequested)
                        break;
                }
            }, token2);


            if (Console.ReadKey().KeyChar == ' ')
                cts2.Cancel();
        }
    }
}