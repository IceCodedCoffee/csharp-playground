namespace _04._Waiting_for_the_end_of_a_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task task = Task.Run(() =>
            {
                Console.WriteLine("Operation started...");
                Thread.Sleep(5000);
                Console.WriteLine("Operation finished ...");
            });

            task.Wait();

            Console.WriteLine("Task finished ...");
            Console.WriteLine();

            // ----------------------------------------------------------------------------------------------

            Task task1 = Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine("Task #1: done ...");
                Console.WriteLine();
            });

            Task task2 = Task.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("Task #2: done ...");
                Console.WriteLine();
            });

            Task task3 = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Task #3: done ...");
                Console.WriteLine();
            });

            Task.WaitAll(task1, task2, task3);
            // Task.WaitAll(new Task[] { task1, task2, task3 });

            Console.WriteLine("All Tasks completed");
            Console.WriteLine();

            // ----------------------------------------------------------------------------------------------

            Task task4 = Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine("Task #1: done ...");
                Console.WriteLine();
            });

            Task task5 = Task.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("Task #2: done ...");
                Console.WriteLine();
            });

            Task task6 = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Task #3: done ...");
                Console.WriteLine();
            });

            Task.WaitAny(task4, task5, task6);
            // Task.WaitAny(new Task[] { task1, task2, task3 });

            Console.WriteLine("At least one task is completed");
            Console.WriteLine();
        }
    }
}
