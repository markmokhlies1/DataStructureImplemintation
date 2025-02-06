using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToLinkedList
{
    public class SingleLinkedList : ILinkedList
    {
        private class Node
        {
            public object Data;
            public Node Next;

            public Node(object data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node head;
        private int count;
        public void add(int index, object element)
        {
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException();

            Node newNode = new Node(element);
            if (index == 0)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                    current = current.Next;
                newNode.Next = current.Next;
                current.Next = newNode;
            }
            count++;
        }

        public void add(object element)
        {
            add(count, element);
        }

        public void clear()
        {
            head = null;
            count = 0;
        }

        public bool contains(object o)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(o))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public object get(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException();
            Node current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;
            return current.Data;
        }

        public bool isEmpty() => count == 0;

        public void remove(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException();

            if (index == 0)
                head = head.Next;
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                    current = current.Next;
                current.Next = current.Next.Next;
            }
            count--;
        }

        public void set(int index, object element)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException();
            Node current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;
            current.Data = element;
        }

        public int size() => count;

        public ILinkedList sublist(int fromIndex, int toIndex)
        {
            if (fromIndex < 0 || toIndex >= count || fromIndex > toIndex)
                throw new ArgumentOutOfRangeException();

            SingleLinkedList sublist = new SingleLinkedList();
            Node current = head;
            for (int i = 0; i < fromIndex; i++)
                current = current.Next;
            for (int i = fromIndex; i <= toIndex; i++)
            {
                sublist.add(current.Data);
                current = current.Next;
            }
            return sublist;
        }
    }
}
