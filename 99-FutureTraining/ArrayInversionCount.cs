using System;
using System.Linq;
using System.Collections.Generic;

namespace Codility
{
    public class ArrayInversionCount
    {
        // Sort A and use binary search to
        // find sorted indices
        public int solution(int[] A)
        {
            const int limit = (int)1e9;

            var result = 0;
            var sortedNumbers = A.ToList();
            sortedNumbers.Sort();

            for (int i = 0; i < A.Length; i++)
            {
                var sortedIdx = GetFirstIndexOf(sortedNumbers, A[i]);
                result += sortedIdx;

                if (result > limit)
                {
                    return -1;
                }

                sortedNumbers.RemoveAt(sortedIdx);
            }

            return result;
        }

        private int GetFirstIndexOf(List<int> sortedNumbers, int num)
        {
            var low = 0;
            var high = sortedNumbers.Count() - 1;
            var index = -1;

            while (low <= high)
            {
                var mid = (low + high) / 2;

                // Binary search for the sorted index
                // of the first occurence of num
                if (sortedNumbers[mid] == num)
                {
                    index = mid;
                    high = mid - 1;
                }
                else if (sortedNumbers[mid] > num)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return index;
        }

        // Use modifed mergesort
        public int solution2(int[] A)
        {
            return CountInversions(A, 0, A.Length - 1);
        }

        public int CountInversions(int[] A, int first, int last)
        {
            if (first >= last)
            {
                return 0;
            }

            const int limit = (int)1e9;
            var mid = (first + last) / 2;

            // Divide array in half and sort recursively
            var countLeft = CountInversions(A, first, mid);
            var countRight = CountInversions(A, mid + 1, last);

            if (countLeft == -1 || countRight == -1)
            {
                return -1;
            }

            var sorted = new int[last - first + 1];
            var sortedIdx = 0;
            var leftIdx = first;
            var rightIdx = mid + 1;
            var countMerge = 0;

            while (leftIdx <= mid && rightIdx <= last)
            {
                if (A[leftIdx] <= A[rightIdx])
                {
                    sorted[sortedIdx++] = A[leftIdx++];
                }
                else
                {
                    sorted[sortedIdx++] = A[rightIdx++];
                    countMerge += mid - leftIdx + 1;
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

            var result = countLeft + countMerge + countRight;
            return result < limit ? result : -1;
        }
    }
}
