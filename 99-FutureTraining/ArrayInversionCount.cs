using System;
using System.Linq;
using System.Collections.Generic;

namespace Codility
{
    public class ArrayInversionCount
    {
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
    }
}
