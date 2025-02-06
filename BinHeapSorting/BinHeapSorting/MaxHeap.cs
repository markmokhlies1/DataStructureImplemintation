using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinHeapSorting
{
    public class MaxHeap
    {
        private readonly int[] heapArray;
        private readonly int maxSize;
        private int size;

        public MaxHeap(int maxSize)
        {
            this.maxSize = maxSize;
            heapArray = new int[maxSize];
            this.size = 0;
        }

        public MaxHeap(int[] arr, int maxSize)
        {
            this.maxSize = maxSize;
            this.size = arr.Length;
            heapArray = new int[maxSize];
            Array.Copy(arr, heapArray, size);
            for (int i = size - 1; i >= 0; i--)
            {
                MaxHeapifyDown(i);
            }
        }

        private MaxHeap(int[] arr)
        {
            this.maxSize = arr.Length;
            this.size = arr.Length;
            heapArray = arr;
            for (int i = size - 1; i >= 0; i--)
            {
                MaxHeapifyDown(i);
            }
        }

        private void MaxHeapifyDown(int index)
        {
            int largest = index;
            int left = LeftChild(index);
            int right = RightChild(index);

            if (left < size && heapArray[left] > heapArray[largest])
                largest = left;

            if (right < size && heapArray[right] > heapArray[largest])
                largest = right;

            if (largest != index)
            {
                Swap(index, largest);
                MaxHeapifyDown(largest);
            }
        }

        private void MaxHeapifyUp(int index)
        {
            if (index != 0 && heapArray[Parent(index)] < heapArray[index])
            {
                Swap(Parent(index), index);
                MaxHeapifyUp(Parent(index));
            }
        }

        public static void HeapSort(int[] arr, List<int[]> steps, bool inter)
        {
            if (arr.Length <= 1) return;
            MaxHeap maxHeap = new MaxHeap(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                maxHeap.ExtractMax();
                if (!inter) steps.Add((int[])arr.Clone());
            }
        }

        public void Insert(int value)
        {
            if (size == maxSize)
            {
                throw new InvalidOperationException("Heap size limit exceeded.");
            }
            heapArray[size] = value;
            int currentIndex = size++;
            MaxHeapifyUp(currentIndex);
        }

        public int ExtractMax()
        {
            int max = GetMax();
            size--;
            if (size != 0)
            {
                Swap(0, size);
                MaxHeapifyDown(0);
            }
            return max;
        }

        public int GetMax()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Heap is empty.");
            }
            return heapArray[0];
        }

        private int Parent(int index) => (index - 1) / 2;
        private int LeftChild(int index) => (2 * index) + 1;
        private int RightChild(int index) => (2 * index) + 2;

        private void Swap(int i, int j)
        {
            int temp = heapArray[i];
            heapArray[i] = heapArray[j];
            heapArray[j] = temp;
        }

        public void PrintHeap()
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write(heapArray[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
