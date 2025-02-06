namespace AVL
{
    public interface IBinarySearchTree<K> where K : IComparable<K>
    {
        bool Insert(K key);
        bool Delete(K key);
        bool Search(K key);
        int Size();
        int Height();
    }
}
