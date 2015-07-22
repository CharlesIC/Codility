using System;

namespace Codility
{
    public class SelectionSort
    {
        public int[] Sort(int[] arr)
        {
            var n = arr.Length;
            var ops = 0;

            for (int i = 0; i < n; i++)
            {
                var minimal = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (arr[minimal] > arr[j])
                    {
                        minimal = j;
                    }  

                    ops++;
                }

                var temp = arr[i];
                arr[i] = arr[minimal];
                arr[minimal] = temp;
            }

            Console.WriteLine("n: " + n + ", ops: " + ops);
            return arr;
        }
    }
}

