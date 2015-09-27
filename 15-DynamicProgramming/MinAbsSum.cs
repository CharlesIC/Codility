using System;
using System.Linq;
using System.Collections.Generic;

namespace Codility
{
    public class MinAbsSum
    {
        public int solution(int[] A)
        {
            var n = A.Length;
            var result = 0;

            foreach (var num in A)
            {
                result = Math.Min(Math.Abs(result + num), Math.Abs(result - num));
            }

            return result;
        }

        public int solution2(int[] A)
        {
            if (A.Length == 0)
            {
                return 0;
            }

            var sums = new List<int> { A[0] };

            for (int i = 1; i < A.Length; i++)
            {
                var num = A[i];
                var newSums = new List<int>();

                foreach (var sum in sums)
                {
                    newSums.Add(Math.Abs(sum + num));
                    newSums.Add(Math.Abs(sum - num));
                }

                sums = newSums;
            }

            return sums.Min();
        }
    }
}
