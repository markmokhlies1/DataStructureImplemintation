namespace RedBlack
{
    public class RedBlackNode<K> where K : IComparable<K>
    {
        public K Value { get; set; }
        public RedBlackNode<K> Left { get; set; }
        public RedBlackNode<K> Right { get; set; }
        public RedBlackNode<K> Parent { get; set; }
        public int Color { get; set; } // 0 = Black, 1 = Red

        public RedBlackNode(K value)
        {
            Value = value;
            Left = null;
            Right = null;
            Parent = null;
            Color = 1; // Default color is red
        }
    }

}
