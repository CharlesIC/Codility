using System;

namespace Codility
{
    public class MinMaxDivision
    {
        public int Solution(int K, int M, int[] A)
        {
            var prefixSums = PrefixSums(A);

            var beg = 1;
            var end = A.Length;
            var result = prefixSums[A.Length];

            if (K == 1)
            {
                return result;
            }

            while (beg <= end)
            {
                var mid = (beg + end) / 2;
                int sum;

                if (GetMinSum(prefixSums, K, mid, A.Length, out sum))
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

        private bool GetMinSum(int[] prefixSums, int numBlocks, int maxBlockSize, int arrLength, out int minSum)
        {
            var countRemainingElements = arrLength - maxBlockSize;
            var totalSum = prefixSums[arrLength];
            var anyValid = false;

            if (countRemainingElements == 0)
            {
                minSum = totalSum;
                return true;
            }

            minSum = totalSum;
            
            for (int i = 0; i <= arrLength - maxBlockSize; i++)
            {
                var blockSum = SumBetweenIndices(prefixSums, i, i + maxBlockSize - 1);
                var remainingSum = totalSum - blockSum;
                var countRemainingBlocks = Math.Min((numBlocks - 1), countRemainingElements);

                if ((remainingSum / countRemainingBlocks) < blockSum)
                {
                    minSum = Math.Min(minSum, blockSum);
                    anyValid = true;
                }
            }

            return anyValid;
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
