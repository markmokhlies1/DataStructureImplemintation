namespace ArrayOperation
{
    public class ArrayOperation : IArrayOperation
    {
        public double Average(int[] arr)
        {
            double sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            }
            return sum /(double) arr.Count();
        }

        public int Fibonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        public int[] MoveValue(int[] arr, int val)
        {
            int index = 0;

            // Move all elements not equal to val to the front
            foreach (int num in arr)
            {
                if (num != val)
                {
                    arr[index++] = num;
                }
            }

            // Fill the remaining part with val
            while (index < arr.Length)
            {
                arr[index++] = val;
            }

            return arr;
        }

        public int[] Revrse(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left < right)
            {
                // Swap elements
                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;

                // Move pointers
                left++;
                right--;
            }
            return arr;
        }

        public int[] SumEvenOdd(int[] arr)
        {
            if (arr.Length == 0) return new int[] { 0, 0 }; // Return [0, 0] for an empty array

            int sumEven = 0;
            int sumOdd = 0;

            foreach (int num in arr)
            {
                if (num % 2 == 0)
                    sumEven += num;
                else
                    sumOdd += num;
            }

            return new int[] { sumEven, sumOdd };
        }

        public int[][] Transpose(int[][] arr)
        {
            if (arr.Length == 0 || arr[0].Length == 0)
                return new int[0][];  // Return an empty array if input is empty

            int rows = arr.Length;
            int cols = arr[0].Length;
            int[][] result = new int[cols][];

            // Initialize each row in the result array
            for (int i = 0; i < cols; i++)
            {
                result[i] = new int[rows];
            }

            // Fill the transposed matrix
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[j][i] = arr[i][j];
                }
            }

            return result;
        }
    }
}
