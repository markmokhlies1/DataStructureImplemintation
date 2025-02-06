namespace QueueImplemntation
{
    public interface IQueue
    {
        void Enqueue(object item); // Inserts an item at the queue front
        object Dequeue();          // Removes and returns the object at the queue rear
        bool IsEmpty();            // Tests if the queue is empty
        int Size();                // Returns the number of elements in the queue
    }

}
