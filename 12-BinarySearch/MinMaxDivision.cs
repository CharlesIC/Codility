using System;

namespace Codility
{
    public class MinMaxDivision
    {
        public int Solution(int K, int M, int[] A)
        {
            var prefixSums = PrefixSums(A);

            var beg = 1;
            var end = M;
            var result = SumBetweenIndices(prefixSums, 0, A.Length - 1);

            if (K == 1)
            {
                if (M >= A.Length)
                {
                    return result;
                }

                return -1;
            }

            while (beg <= end)
            {
                var mid = (beg + end) / 2;
                var sum = GetMinSum(prefixSums, K, mid, A.Length);

                if (sum < result)
                {
                    result = Math.Min(result, sum);
                    end = mid - 1;
                }
                else
                {
                    beg = mid + 1;
                }
            }

            return result;
        }

        private int GetMinSum(int[] prefixSums, int numBlocks, int maxBlockSize, int arrLength)
        {
            var totalSum = SumBetweenIndices(prefixSums, 0, arrLength - 1);
            var minSum = totalSum;
            
            for (int i = 0; i <= arrLength - maxBlockSize; i++)
            {
                var blockSum = SumBetweenIndices(prefixSums, i, i + maxBlockSize - 1);
                var remainingSum = totalSum - blockSum;

                if ((remainingSum / (numBlocks - 1)) < blockSum)
                {
                    minSum = Math.Min(minSum, blockSum);
                }
            }

            return minSum;
        }

        private int[] PrefixSums(int[] arr)
        {
            var sums = new int[arr.Length + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                sums[i + 1] = sums[i] + arr[i];
            }

            return sums;
        }

        private int SumBetweenIndices(int[] prefixSums, int a, int b)
        {
            return prefixSums[b + 1] - prefixSums[a];
        }
    }
}
