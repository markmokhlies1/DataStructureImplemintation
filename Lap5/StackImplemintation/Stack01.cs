namespace StackImplemintation
{
    public class Stack01 : IStake
    {
        Queue<object> queue;
        public Stack01()
        {
            queue = new Queue<object>();
        }
        public bool isEmpty()
        {
            return queue.Count == 0;
        }

        public object peek()
        {
            if (isEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return queue.Peek();
        }

        public object pop()
        {
            if (isEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return queue.Dequeue();
        }

        public void push(object element)
        {
            Queue<object> tempQueue = new Queue<object>();

            tempQueue.Enqueue(element);

            while (queue.Count > 0)
            {
                tempQueue.Enqueue(queue.Dequeue());
            }
            queue = tempQueue;
        }

        public int size()
        {
            return queue.Count;
        }
    }
}
