using System;

namespace Codility
{
    public class MinAbsSumOfTwo
    {
        public int solution(int[] A)
        {
            Array.Sort(A);

            var tail = 0;
            var head = A.Length - 1;

            // All positive
            if (A[tail] >= 0)
            {
                return A[tail] + A[tail];
            }

            // All negative
            if (A[head] <= 0)
            {
                return Math.Abs(A[head] + A[head]);
            }

            var result = Math.Abs(A[tail] + A[head]);

            while (tail <= head)
            {
                var temp = Math.Abs(A[tail] + A[head]);
                result = Math.Min(result, temp);

                if (Math.Abs(A[tail + 1] + A[head]) < temp)
                {
                    tail++;
                }
                else if (Math.Abs(A[tail] + A[head - 1]) < temp)
                {
                    head--;
                }
                else
                {
                    tail++;
                    head--;
                }
            }

            return result;
        }
    }
}
