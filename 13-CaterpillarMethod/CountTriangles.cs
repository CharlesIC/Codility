using System;

namespace Codility
{
    public class CountTriangles
    {
        public int solution(int[] A)
        {
            var result = 0;

            Array.Sort(A);

            for (int x = 0; x < A.Length; x++)
            {
                var z = 0;
                for (int y = x + 1; y < A.Length; y++)
                {
                    while (z < A.Length && A[x] + A[y] > A[z])
                    {
                        z++;
                    }

                    result += z - y - 1;
                }
            }
                
            return result;
        }
    }
}
