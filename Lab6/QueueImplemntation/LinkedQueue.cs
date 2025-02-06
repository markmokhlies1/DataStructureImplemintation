namespace QueueImplemntation
{
    public class LinkedQueue : IQueue, ILinkedBased
    {
        private class Node
        {
            public object Data;
            public Node Next;

            public Node(Object data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node front; // Points to the front of the queue
        private Node rear;  // Points to the rear of the queue
        private int count;  // Tracks the number of elements in the queue

        public LinkedQueue()
        {
            front = rear = null;
            count = 0;
        }

        public void Enqueue(object item)
        {
            Node newNode = new Node(item);

            if (IsEmpty())
            {
                front = rear = newNode;
            }
            else
            {
                rear.Next = newNode;
                rear = newNode;
            }

            count++;
        }

        public object Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            Object data = front.Data;
            front = front.Next;
            count--;

            if (front == null) // Queue becomes empty
            {
                rear = null;
            }

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
