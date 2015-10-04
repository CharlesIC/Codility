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
                var low = 0;
                var high = sortedNumbers.Count - 1;
                var sortedIdx = -1;

                while (low <= high)
                {
                    var mid = (low + high) / 2;

                    // Binary search for the sorted index
                    // of the first occurence of A[i]
                    if (sortedNumbers[mid] == A[i])
                    {
                        sortedIdx = mid;
                        high = mid - 1;
                    }
                    else if (sortedNumbers[mid] > A[i])
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }

                result += sortedIdx;

                if (result > limit)
                {
                    return -1;
                }

                sortedNumbers.RemoveAt(sortedIdx);
            }

            return result;
        }
    }
}
