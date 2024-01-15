namespace _06._Handling_exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task task = Task.Run(() => { throw new DivideByZeroException(); });

            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                AggregateException aggEx = ex.Flatten();

                aggEx.Handle(type =>
                {
                    if (type is DivideByZeroException)
                    {
                        Console.WriteLine("Division by 0 is not allowed.");
                        return true;
                    }

                    return false;
                });
            }

            Console.WriteLine("Anwendung beendet");
            Console.WriteLine();

            // ----------------------------------------------------------------------------------------------

            try
            {
                Task task1 = new Task(() => { throw new DivideByZeroException(); });
                Task task2 = new Task(() => { throw new InvalidCastException(); });
                Task task3 = new Task(() => { throw new InvalidProgramException(); });

                task1.Start();
                task2.Start();
                task3.Start();

                Task.WaitAll(task1, task2, task3);
            }
            catch (AggregateException ex)
            {
                AggregateException aggEx = ex.Flatten();
                ex.Handle(type =>
                {
                    if (type is DivideByZeroException)
                    {
                        Console.WriteLine("Nulldivision ist nicht erlaubt.");
                        Console.WriteLine();
                        return true;
                    }
                    if (type is InvalidCastException)
                    {
                        Console.WriteLine("Nicht mögliche Typumwandlung.");
                        Console.WriteLine();
                        return true;
                    }
                    if (type is InvalidProgramException)
                    {
                        Console.WriteLine("Fehler im Programm.");
                        Console.WriteLine();
                        return true;
                    }
                    return false;
                });
            }
            Console.WriteLine("Anwendung beendet");
        }
    }
}