using System.Threading.Tasks;

namespace _07._Processing_methods_in_parallel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(Task1, Task2, Task3, Task4, Task5, Task6, Task7, Task8, Task9, Task10);
        }

        static void Task1()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(50);
                Console.Write(" #1 ");
            }
        }

        static void Task2()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(50);
                Console.Write(" #2 ");
            }
        }

        static void Task3()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(50);
                Console.Write(" #3 ");
            }
        }

        static void Task4()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(50);
                Console.Write(" #4 ");
            }
        }

        static void Task5()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(50);
                Console.Write(" #5 ");
            }
        }

        static void Task6()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(50);
                Console.Write(" #6 ");
            }
        }

        static void Task7()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(50);
                Console.Write(" #7 ");
            }
        }

        static void Task8()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(50);
                Console.Write(" #8 ");
            }
        }

        static void Task9()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(50);
                Console.Write(" #9 ");
            }
        }

        static void Task10()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(50);
                Console.Write(" #10 ");
            }
        }
    }
}