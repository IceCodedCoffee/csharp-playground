using System.Threading.Tasks;

namespace _01._Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new Task(new Action(DoSomething));

            task1.Start();

            Console.WriteLine();

            // ----------------------------------------------------------------------------------------------

            Task.Factory.StartNew(new Action(DoSomething));

            Console.WriteLine();

            // ----------------------------------------------------------------------------------------------

            Task.Run(() =>
            {
                var id = Thread.CurrentThread.ManagedThreadId;

                Console.WriteLine($"Task #{id}");
            });

            Console.WriteLine();

            // ----------------------------------------------------------------------------------------------

            Parallel.Invoke(Task1);
            Console.ReadLine();
        }

        private static void DoSomething()
        {
            Console.WriteLine($"In method DoSomething");
        }

        static void Task1()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(50);
                Console.Write(" #1 ");
            }
        }
    }
}