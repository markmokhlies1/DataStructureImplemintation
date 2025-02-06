using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToLinkedList
{
    internal class DoubleLinkedList : ILinkedList
    {
        private class Node
        {
            public object Data;
            public Node Next;
            public Node Prev;

            public Node(object data)
            {
                Data = data;
                Next = Prev = null;
            }
        }

        private Node head;
        private Node tail;
        private int count;
        public void add(int index, object element)
        {
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException();

            Node newNode = new Node(element);
            if (index == 0)
            {
                if (head == null)
                    head = tail = newNode;
                else
                {
                    newNode.Next = head;
                    head.Prev = newNode;
                    head = newNode;
                }
            }
            else if (index == count)
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index; i++)
                    current = current.Next;

                newNode.Next = current;
                newNode.Prev = current.Prev;
                current.Prev.Next = newNode;
                current.Prev = newNode;
            }
            count++;
        }

        public void add(object element)
        {
            add(count, element);
        }

        public void clear()
        {
            head = tail = null;
            count = 0;
        }

        public bool contains(object o)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(o)) return true;
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
            {
                head = head.Next;
                if (head != null)
                    head.Prev = null;
                else
                    tail = null;
            }
            else if (index == count - 1)
            {
                tail = tail.Prev;
                tail.Next = null;
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index; i++)
                    current = current.Next;

                current.Prev.Next = current.Next;
                current.Next.Prev = current.Prev;
            }
            count--;
        }

        public void set(int index, object element)
        {
            Node current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;
            current.Data = element;
        }

        public int size() => count;
        public ILinkedList sublist(int fromIndex, int toIndex)
        {
            DoubleLinkedList sublist = new DoubleLinkedList();
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
