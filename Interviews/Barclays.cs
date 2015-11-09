using System;

namespace Codility
{
    public class Barclays
    {
        public int solution(int A, int B)
        {
            var min = A > 0 ? A : 0;
            var max = B;

            var first = (int)Math.Sqrt(min);
            var last = (int)Math.Sqrt(max);

            return last - first + 1;
        }

        public int solution2(int[] A)
        {
            if (A.Length == 2)
            {
                return Math.Abs(A[1] - A[0]);
            }

            Array.Sort(A);

            var minDistance = Math.Abs(A[1] - A[0]);

            for (int i = 1; i < A.Length; i++)
            {
                minDistance = Math.Min(minDistance, Math.Abs(A[i] - A[i - 1]));
            }
                
            return minDistance;
        }
    }
}
