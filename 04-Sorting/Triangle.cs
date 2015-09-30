using System;

namespace Codility
{
    public class Triangle
    {
        public int Solution(int[] A)
        {
            if (A.Length < 3)
            {
                return 0;
            }

            Array.Sort(A);

            for (int i = 0; i < A.Length - 2; i++)
            {
                ulong sum = (uint)A[i] + (uint)A[i + 1];
                if (sum > (uint)A[i + 2])
                {
                    return 1;
                }
            }

            return 0;
        }
    }
}

