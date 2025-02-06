namespace AVL
{
    public class AVLNode<K> where K : IComparable<K>
    {
        public K Value { get; set; }
        public AVLNode<K> Left { get; set; }
        public AVLNode<K> Right { get; set; }
        public int Height { get; set; }

        public bool HasLeft() => Left != null;

        public AVLNode(K value)
        {
            Value = value;
            Left = null;
            Right = null;
            Height = 1;
        }
    }
}
