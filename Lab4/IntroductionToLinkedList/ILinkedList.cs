namespace IntroductionToLinkedList
{
    public interface ILinkedList
    {
        public void add(int index, object element);
        public void add(object element);
        public object get(int index);
        public void set(int index, object element);
        public void clear();
        public bool isEmpty();
        public void remove(int index);
        public int size();
        public ILinkedList sublist(int fromIndex, int toIndex);
        public bool contains(Object o);
    }
}
