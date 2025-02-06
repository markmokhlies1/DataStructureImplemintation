namespace QueueImplemntation
{
    public class ArrayQueue : IQueue, IArrayBased
    {
        private object[] array;
        private int front;   // Points to the front of the queue
        private int rear;    // Points to the rear of the queue
        private int count;   // Tracks the number of elements in the queue
        private int capacity;

        public ArrayQueue(int n)
        {
            capacity = n;
            array = new object[capacity];
            front = 0;
            rear = -1;
            count = 0;
        }

        public void Enqueue(Object item)
        {
            if (count == capacity)
            {
                throw new InvalidOperationException("Queue is full.");
            }

            rear = (rear + 1) % capacity;
            array[rear] = item;
            count++;
        }

        public object Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            object data = array[front];
            front = (front + 1) % capacity;
            count--;

            return data;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public int Size()
        {
            return count;
        }
    }

}
