using System;

namespace Codility
{
    public static class Sort
    {
        public static void Mergesort(int[] A, int first, int last)
        {
            if (first >= last || first < 0 || last >= A.Length)
            {
                return;
            }

            var mid = (first + last) / 2;

            // Divide array in half and sort recursively
            Mergesort(A, first, mid);
            Mergesort(A, mid + 1, last);

            var sorted = new int[last - first + 1];
            var sortedIdx = 0;
            var leftIdx = first;
            var rightIdx = mid + 1;

            while (leftIdx <= mid && rightIdx <= last)
            {
                if (A[leftIdx] <= A[rightIdx])
                {
                    sorted[sortedIdx++] = A[leftIdx++];
                }
                else
                {
                    sorted[sortedIdx++] = A[rightIdx++];
                }
            }

            if (leftIdx != mid + 1)
            {
                while (leftIdx <= mid)
                {
                    sorted[sortedIdx++] = A[leftIdx++];
                }
            }

            if (rightIdx != last + 1)
            {
                while (rightIdx <= last)
                {
                    sorted[sortedIdx++] = A[rightIdx++];
                }
            }

            for (int i = first; i <= last; i++)
            {
                A[i] = sorted[i - first];
            }
        }
    }
}
