namespace RedBlack
{
    public class RedBlackTree<K> where K : IComparable<K>
    {
        private RedBlackNode<K> root;
        private RedBlackNode<K> TNULL; // Sentinel node to represent NULL

        public RedBlackTree()
        {
            TNULL = new RedBlackNode<K>(default(K)) { Color = 0 }; // Black color for sentinel node
            root = TNULL;
        }

        public void Insert(K key)
        {
            RedBlackNode<K> node = new RedBlackNode<K>(key);
            RedBlackNode<K> temp = root;
            RedBlackNode<K> parent = null;

            while (temp != TNULL)
            {
                parent = temp;
                if (key.CompareTo(temp.Value) < 0)
                {
                    temp = temp.Left;
                }
                else if (key.CompareTo(temp.Value) > 0)
                {
                    temp = temp.Right;
                }
                else
                {
                    return; // No duplicates allowed
                }
            }

            node.Parent = parent;
            if (parent == null)
            {
                root = node;
            }
            else if (key.CompareTo(parent.Value) < 0)
            {
                parent.Left = node;
            }
            else
            {
                parent.Right = node;
            }

            node.Left = TNULL;
            node.Right = TNULL;
            node.Color = 1; // Red color for newly inserted node
            FixInsert(node);
        }

        private void FixInsert(RedBlackNode<K> node)
        {
            RedBlackNode<K> uncle;

            while (node.Parent.Color == 1)
            {
                if (node.Parent == node.Parent.Parent.Right)
                {
                    uncle = node.Parent.Parent.Left;
                    if (uncle.Color == 1)
                    {
                        uncle.Color = 0;
                        node.Parent.Color = 0;
                        node.Parent.Parent.Color = 1;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.Left)
                        {
                            node = node.Parent;
                            RightRotate(node);
                        }
                        node.Parent.Color = 0;
                        node.Parent.Parent.Color = 1;
                        LeftRotate(node.Parent.Parent);
                    }
                }
                else
                {
                    uncle = node.Parent.Parent.Right;
                    if (uncle.Color == 1)
                    {
                        uncle.Color = 0;
                        node.Parent.Color = 0;
                        node.Parent.Parent.Color = 1;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.Right)
                        {
                            node = node.Parent;
                            LeftRotate(node);
                        }
                        node.Parent.Color = 0;
                        node.Parent.Parent.Color = 1;
                        RightRotate(node.Parent.Parent);
                    }
                }
                if (node == root)
                {
                    break;
                }
            }
            root.Color = 0;
        }

        private void LeftRotate(RedBlackNode<K> x)
        {
            RedBlackNode<K> y = x.Right;
            x.Right = y.Left;
            if (y.Left != TNULL)
            {
                y.Left.Parent = x;
            }
            y.Parent = x.Parent;
            if (x.Parent == null)
            {
                root = y;
            }
            else if (x == x.Parent.Left)
            {
                x.Parent.Left = y;
            }
            else
            {
                x.Parent.Right = y;
            }
            y.Left = x;
            x.Parent = y;
        }

        private void RightRotate(RedBlackNode<K> x)
        {
            RedBlackNode<K> y = x.Left;
            x.Left = y.Right;
            if (y.Right != TNULL)
            {
                y.Right.Parent = x;
            }
            y.Parent = x.Parent;
            if (x.Parent == null)
            {
                root = y;
            }
            else if (x == x.Parent.Right)
            {
                x.Parent.Right = y;
            }
            else
            {
                x.Parent.Left = y;
            }
            y.Right = x;
            x.Parent = y;
        }

        public bool Search(K key)
        {
            RedBlackNode<K> node = root;
            while (node != TNULL)
            {
                if (key.CompareTo(node.Value) == 0)
                {
                    return true;
                }
                else if (key.CompareTo(node.Value) < 0)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }
            return false;
        }

        public int Size()
        {
            return Size(root);
        }

        private int Size(RedBlackNode<K> node)
        {
            if (node == TNULL)
            {
                return 0;
            }
            return Size(node.Left) + Size(node.Right) + 1;
        }
    }

}
