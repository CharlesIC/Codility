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

            for (int back = 0; back < A.Length; back++)
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
               
                if (result >= limit)
                {
                    return limit;
                }

                back = front - 1;
            }

            return Math.Min(limit, result);
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
                    front++;
                }

                var n = front - back;
                result += (n + 1) * n / 2;

                if (result >= limit)
                {
                    return limit;
                }

                back = 
                    front - back > 1 ?
                    front - 1 : 
                    back + 1;
            }

            return Math.Min(limit, result);
        }

        public int solution3(int M, int[] A)
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

            return result < limit ? result : limit;
        }
    }
}
