using System;
using System.Collections.Generic;

namespace Codility
{
    public class CountDistinctSlices
    {
        public int solution(int M, int[] A)
        {
            const int limit = (int)1e9;
            var result = 0;

            var back = 0;
            while (back < A.Length)
            {
                var elements = new HashSet<int>();

                var front = back;
                while (front < A.Length && !elements.Contains(A[front]) && result < limit)
                {
                    elements.Add(A[front]);
                    front++;
                }

                var n = front - back;
                result += (n + 1) * n / 2;

                back = front;

                if (front < A.Length && A[front] != A[front - 1])
                {
                    result--;
                    back--;
                }

                if (result >= limit)
                {
                    return limit;
                }
            }

            return Math.Min(result, limit);
        }

        public int solution2(int M, int[] A)
        {
            const int limit = (int)1e9;
            var result = 0;

            var back = 0;
            while (back < A.Length)
            {
                var elements = new HashSet<int>();

                var front = back;
                while (front < A.Length && !elements.Contains(A[front]) && result < limit)
                {
                    elements.Add(A[front]);
                    result += elements.Count;
                    front++;
                }

                if (result >= limit)
                {
                    return limit;
                }

                back = Math.Max(front - 1, back + 1);
            }
                
            return Math.Min(result, limit);
        }

        public int solution3(int M, int[] A)
        {
            const int limit = (int)1e9;
            var result = 0;
            int back, front;

            back = front = 0;
            while (back < A.Length && front < A.Length)
            {
                var elements = new HashSet<int>();

                front = back;
                while (front < A.Length && !elements.Contains(A[front]) && result < limit)
                {
                    elements.Add(A[front]);
                    result += elements.Count;
                    front++;
                }

                if (front < A.Length)
                {
                    if (A[front] == A[front - 1])
                    {
                        back = front;
                    }
                    else
                    {
                        back = front - 1;
                        result--;
                    }
                }

                if (result >= limit)
                {
                    return limit;
                }
            }

            return Math.Min(result, limit);
        }

        public int solution4(int M, int[] A)
        {
            const int limit = (int)1e9;
            int back, front;
            var result = 0;

            var elements = new HashSet<int>();

            front = 0;
            while (front < A.Length)
            {
                if (!elements.Contains(A[front]))
                {
                    elements.Add(A[front]);
                    result += elements.Count;
                    front++;
                }
                else
                {
                    elements.Clear();

                    if (A[front] == A[front - 1])
                    {
                        back = front;
                    }
                    else
                    {
                        back = --front;
                        result--;
                    }

                    if (result >= limit)
                    {
                        return limit;
                    }
                }
            }

            return Math.Min(result, limit);
        }

        public int solution5(int M, int[] A)
        {
            return -1;
        }
    }
}
