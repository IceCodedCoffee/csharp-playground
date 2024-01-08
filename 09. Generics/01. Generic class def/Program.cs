namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Stack<int> stack = new Stack<int>(10);

                stack.Push(123);
                stack.Push(4711);
                stack.Push(34);

                for (int i = stack.Length; i > 0; i--)
                {
                    Console.WriteLine(stack.Pop());
                }

                stack.Pop();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
