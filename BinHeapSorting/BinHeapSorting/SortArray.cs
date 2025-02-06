using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinHeapSorting
{
    public class SortArray
    {
        private readonly int[] arr; // The array to be sorted
        private List<int[]> list; // The intermediate arrays

        // Constructor to read array from file
        public SortArray(string filename)
        {
            arr = ReadFromFile(filename);
        }

        private int[] ReadFromFile(string filename)
        {
            try
            {
                string[] lines = File.ReadAllLines(filename);
                return Array.ConvertAll(lines, int.Parse);
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading file: " + ex.Message);
            }
        }

        public object SimpleSort(bool choice)
        {
            list = new List<int[]>();
            int[] unsorted = (int[])arr.Clone();
            if (!choice) list.Add((int[])unsorted.Clone());
            BubbleSort(unsorted, choice);
            return choice ? unsorted : list.ToArray();
        }

        public object EfficientSort(bool choice)
        {
            list = new List<int[]>();
            int[] unsorted = (int[])arr.Clone();
            if (!choice) list.Add((int[])unsorted.Clone());
            MergeSort(unsorted, choice, 0, arr.Length - 1);
            return choice ? unsorted : list.ToArray();
        }

        public object NonComparisonSort(bool choice)
        {
            if (arr.Length == 0) throw new IndexOutOfRangeException();
            list = new List<int[]>();
            int[] unsorted = (int[])arr.Clone();
            CountSort(unsorted, choice);
            return choice ? unsorted : list.ToArray();
        }

        public object HeapSort(bool choice)
        {
            list = new List<int[]>();
            int[] unsorted = (int[])arr.Clone();
            if (!choice) list.Add((int[])unsorted.Clone());
            MaxHeap.HeapSort(unsorted, list, choice);
            return choice ? unsorted : list.ToArray();
        }

        private void BubbleSort(int[] unsorted, bool choice)
        {
            bool flag = true;
            for (int i = 0; i < unsorted.Length - 1 && flag; i++)
            {
                flag = false;
                for (int j = 0; j < unsorted.Length - i - 1; j++)
                {
                    if (unsorted[j] > unsorted[j + 1])
                    {
                        Swap(ref unsorted[j], ref unsorted[j + 1]);
                        flag = true;
                    }
                }
                if (!choice)
                    list.Add((int[])unsorted.Clone());
            }
        }

        private void MergeSort(int[] unsorted, bool choice, int l, int r)
        {
            if (l < r)
            {
                int mid = (l + r) / 2;
                MergeSort(unsorted, choice, l, mid);
                MergeSort(unsorted, choice, mid + 1, r);
                Merge(unsorted, l, mid, r);
                if (!choice)
                    list.Add((int[])unsorted.Clone());
            }
        }

        private void Merge(int[] unsorted, int l, int mid, int r)
        {
            int leftSize = mid - l + 1;
            int rightSize = r - mid;
            int[] left = new int[leftSize];
            int[] right = new int[rightSize];

            Array.Copy(unsorted, l, left, 0, leftSize);
            Array.Copy(unsorted, mid + 1, right, 0, rightSize);

            int i = 0, j = 0, k = l;
            while (i < leftSize && j < rightSize)
            {
                unsorted[k++] = left[i] <= right[j] ? left[i++] : right[j++];
            }
            while (i < leftSize) unsorted[k++] = left[i++];
            while (j < rightSize) unsorted[k++] = right[j++];
        }

        private void CountSort(int[] arr, bool choice)
        {
            int max = arr[0], min = arr[0];
            foreach (int num in arr)
            {
                if (num > max) max = num;
                if (num < min) min = num;
            }

            int range = max - min + 1;
            if (range < 0) throw new ArgumentOutOfRangeException();
            int[] count = new int[range];
            int[] sorted = new int[arr.Length];

            foreach (int num in arr) count[num - min]++;
            for (int i = 1; i < range; i++) count[i] += count[i - 1];
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                sorted[--count[arr[i] - min]] = arr[i];
                if (!choice) list.Add((int[])sorted.Clone());
            }
            Array.Copy(sorted, arr, arr.Length);
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
