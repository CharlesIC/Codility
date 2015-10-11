using System;
using System.Linq;
using System.Collections.Generic;

namespace Codility
{
    public class ArrayInversionCount
    {
        #region Public Methods

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

        // Use modifed mergesort
        public int solution2(int[] A)
        {
            return CountInversions(A, 0, A.Length - 1);
        }
            
        // Use BIT (Binary Index Tree)
        public int solution3(int[] A)
        {
            const int limit = (int)1e9;
            var n = A.Length;

            var bit = new BinaryIndexTree(n);

            var sortedNumbers = A.ToList();
            sortedNumbers.Sort();

            var result = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                var sortedIdx = GetFirstIndexOf(sortedNumbers, A[i]) + 1;
                result += bit.ReadCumulative(sortedIdx - 1);
                bit.Update(sortedIdx);
            }

            return result <= limit ? result : -1;
        }

        #endregion

        #region Methods

        private int GetFirstIndexOf(List<int> sortedNumbers, int num)
        {
            var low = 0;
            var high = sortedNumbers.Count() - 1;
            var best = -1;

            while (low <= high)
            {
                var mid = (low + high) / 2;

                // Binary search for the sorted index
                // of the first occurence of num
                if (sortedNumbers[mid] == num)
                {
                    best = mid;
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

            return best;
        }

        private int CountInversions(int[] A, int first, int last)
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

        #endregion
    }
}
