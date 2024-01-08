namespace Generics
{
    class Stack<T>
    {
        private readonly int size;
        private T[] elements;
        private int pointer = 0;

        public Stack(int size)
        {
            this.size = size;
            elements = new T[size];
        }

        public void Push(T element)
        {
            if (pointer >= this.size)
            {
                throw new StackOverflowException();
            }

            elements[pointer] = element;
            pointer++;
        }

        public T Pop()
        {
            pointer--;
            if (pointer >= 0)
            {
                return elements[pointer];
            }

            else
            {
                pointer = 0;
                throw new InvalidOperationException("Stack is empty!");
            }
        }

        public int Length => this.pointer;
    }
}
