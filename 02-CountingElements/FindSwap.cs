using System.Collections.Generic;

namespace Codility
{
    public class FindSwap
    {
        public bool Solution(int m, int[] A, int[] B)
        {
            var sumA = this.Sum(A);
            var sumB = this.Sum(B);

            var d = sumB - sumA;

            if (d % 2 == 1)
            {
                return false;
            }

            d /= 2;
            var counterA = this.CountElements(A);

            foreach (var number in B)
            {
                var seek = number - d;
                if (seek > 0 && seek <= m && counterA.Contains(seek))
                {
                    return true;
                }
            }

            return false;
        }

        private int Sum(int[] A)
        {
            var sum = 0;
            foreach (var number in A)
            {
                sum += number;
            }

            return sum;
        }

        private HashSet<int> CountElements(int[] A)
        {
            var counter = new HashSet<int>();

            foreach (var number in A)
            {
                if (!counter.Contains(number))
                {
                    counter.Add(number);
                }
            }

            return counter;
        }
    }
}
