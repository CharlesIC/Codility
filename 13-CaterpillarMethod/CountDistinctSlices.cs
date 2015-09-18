using System;
using System.Collections.Generic;

namespace Codility
{
    public class CountDistinctSlices
    {
        public int solution(int M, int[] A)
        {
            const int limit = 1000000000;
            var elements = new HashSet<int>();
            int back, front, result;

            back = front = result = 0;
            while (front < A.Length && back < A.Length)
            {
                while (front < A.Length && !elements.Contains(A[front]))
                {
                    elements.Add(A[front]);
                    result += (elements.Count);

                    if (result >= limit)
                    {
                        return limit;
                    }

                    front++;
                }

                while (front < A.Length && back < A.Length && A[back] != A[front])
                {
                    elements.Remove(A[back]);
                    back++;
                }

                elements.Remove(A[back]);
                back++;
            }

            return Math.Min(result, limit);
        }
    }
}
