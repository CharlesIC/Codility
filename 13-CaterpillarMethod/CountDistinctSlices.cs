using System;
using System.Collections.Generic;

namespace Codility
{
    public class CountDistinctSlices
    {
        public int solution(int M, int[] A)
        {
            const int limit = 1000000000;
            var elements = new Dictionary<int, int>();
            var result = 0;

            var back = 0;
            for (int front = 0; front < A.Length; front++)
            {
                if (!elements.ContainsKey(A[front]))
                {
                    elements.Add(A[front], front);
                }
                else
                {
                    var nextBack = elements[A[front]] + 1;

                    // S_n = n * (n + 1) / 2
                    // result += (front - back) * (front - back + 1) / 2
                    // result -= (front - nextBack) * (front - nextBack + 1) / 2
                    result += (nextBack - back) * (front - back + front - nextBack + 1) / 2;

                    if (result >= limit)
                    {
                        return limit;
                    }
                        
                    for (int i = back; i < nextBack; i++)
                    {
                        elements.Remove(A[i]);
                    }

                    elements.Add(A[front], front);
                    back = nextBack;
                }
            }

            // Process the last slices
            result += (A.Length - back) * (A.Length - back + 1) / 2;

            return Math.Min(result, limit);
        }

        public int solution2(int M, int[] A)
        {
            const int limit = 1000000000;
            int back, front, result;

            var elements = new int[M + 1];
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = -1;
            }

            back = result = 0;
            for (front = 0; front < A.Length; front++)
            {
                if (elements[A[front]] == -1)
                {
                    elements[A[front]] = front;
                }
                else
                {
                    var newBack = elements[A[front]] + 1;
                    result += (newBack - back) * (front - back + front - newBack + 1) / 2;

                    if (result >= limit)
                    {
                        return limit;
                    }

                    for (int idx = back; idx < newBack; idx++)
                    {
                        elements[A[idx]] = -1;
                    }
                    elements[A[front]] = front;

                    back = newBack;
                }
            }

            result += (front - back) * (front - back + 1) / 2;

            return Math.Min(result, limit);
        }
    }
}
