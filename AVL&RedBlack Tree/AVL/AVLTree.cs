namespace AVL
{
    public class AVLTree<K> : IBinarySearchTree<K> where K : IComparable<K>
    {
        public AVLNode<K> Root { get; set; }
        private int _size;

        public AVLTree()
        {
            Root = null;
            _size = 0;
        }

        public bool Insert(K key)
        {
            if (Search(key))
            {
                return false;
            }
            Root = InsertRec(Root, key);
            _size++;
            return true;
        }

        private AVLNode<K> InsertRec(AVLNode<K> root, K data)
        {
            if (root == null)
            {
                root = new AVLNode<K>(data);
                return root;
            }
            if (data.CompareTo(root.Value) < 0)
            {
                root.Left = InsertRec(root.Left, data);
            }
            else if (data.CompareTo(root.Value) > 0)
            {
                root.Right = InsertRec(root.Right, data);
            }
            UpdateHeight(root);
            return ApplyBalance(root);
        }

        private AVLNode<K> ApplyBalance(AVLNode<K> root)
        {
            int balance = Balance(root);
            if (balance > 1 && Balance(root.Left) >= 0)
            {
                return RightRotate(root);
            }
            if (balance < -1 && Balance(root.Right) <= 0)
            {
                return LeftRotate(root);
            }
            if (balance > 1 && Balance(root.Left) < 0)
            {
                root.Left = LeftRotate(root.Left);
                return RightRotate(root);
            }
            if (balance < -1 && Balance(root.Right) > 0)
            {
                root.Right = RightRotate(root.Right);
                return LeftRotate(root);
            }
            return root;
        }

        private AVLNode<K> LeftRotate(AVLNode<K> root)
        {
            AVLNode<K> rChild = root.Right;
            root.Right = rChild.Left;
            rChild.Left = root;
            UpdateHeight(root);
            UpdateHeight(rChild);
            return rChild;
        }

        private AVLNode<K> RightRotate(AVLNode<K> root)
        {
            AVLNode<K> lChild = root.Left;
            root.Left = lChild.Right;
            lChild.Right = root;
            UpdateHeight(root);
            UpdateHeight(lChild);
            return lChild;
        }

        private int Height(AVLNode<K> node)
        {
            if (node == null)
            {
                return 0;
            }
            return node.Height;
        }

        private int Balance(AVLNode<K> root)
        {
            if (root == null)
            {
                return 0;
            }
            return Height(root.Left) - Height(root.Right);
        }

        private void UpdateHeight(AVLNode<K> root)
        {
            root.Height = Math.Max(Height(root.Left), Height(root.Right)) + 1;
        }

        public bool Delete(K key)
        {
            if (!Search(key))
            {
                return false;
            }
            Root = DeleteRec(Root, key);
            _size--;
            return true;
        }

        private AVLNode<K> DeleteRec(AVLNode<K> root, K data)
        {
            if (root == null)
            {
                return root;
            }
            if (data.CompareTo(root.Value) < 0)
            {
                root.Left = DeleteRec(root.Left, data);
            }
            else if (data.CompareTo(root.Value) > 0)
            {
                root.Right = DeleteRec(root.Right, data);
            }
            else
            {
                if (root.Left == null)
                {
                    return root.Right;
                }
                else if (root.Right == null)
                {
                    return root.Left;
                }
                root.Value = MinValue(root.Right);
                root.Right = DeleteRec(root.Right, root.Value);
            }
            UpdateHeight(root);
            return ApplyBalance(root);
        }

        private K MinValue(AVLNode<K> right)
        {
            AVLNode<K> current = right;
            while (current.Left != null)
                current = current.Left;
            return current.Value;
        }

        private K MaxValue(AVLNode<K> right)
        {
            AVLNode<K> current = right;
            while (current.Right != null)
                current = current.Right;
            return current.Value;
        }

        public bool Search(K key)
        {
            AVLNode<K> temp = Root;
            while (temp != null)
            {
                int cmp = key.CompareTo(temp.Value);
                if (cmp == 0)
                    return true;
                else if (cmp > 0)
                    temp = temp.Right;
                else
                    temp = temp.Left;
            }
            return false;
        }

        public int Size()
        {
            return _size;
        }

        public int Height()
        {
            if (Root == null)
                return -1;
            else
                return Root.Height - 1;
        }
    }
}
