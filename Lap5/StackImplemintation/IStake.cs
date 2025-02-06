namespace StackImplemintation
{
    public interface IStake
    {
        public object pop();
        public object peek();
        public void push(Object element);
        public bool isEmpty();
        public int size();
    }
}
