using System;
using System.Linq;

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

                if ((remainingSum / countRemainingBlocks) <= blockSum)
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


        public int Solution2(int K, int M, int[] A)
        {
            var blocksNeeded = 0;

            var result = 0;
            var lowerBound = A.Max();
            var upperBound = A.Sum();

            // Handle special cases
            if (K == 1)
            {
                return upperBound;
            }

            if (K >= A.Length)
            {
                return lowerBound;
            }
                
            // Binary search for the result
            while (lowerBound <= upperBound)
            {
                var mid = (lowerBound + upperBound) / 2;
                blocksNeeded = GetBlocksNeeded(A, mid);

                if (blocksNeeded <= K)
                {
                    upperBound = mid - 1;
                    result = mid;
                }
                else
                {
                    lowerBound = mid + 1;
                }
            }

            return result;
        }

        private int GetBlocksNeeded(int[] A, int maxBlockSum)
        {
            var countBlocks = 1;
            var preBlockSum = A[0];

            for (int i = 1; i < A.Length; i++)
            {
                // Try to extend the previous block
                if (preBlockSum + A[i] > maxBlockSum)
                {
                    // Can't extend the previous block because
                    // it would exceed the max allowed sum
                    preBlockSum = A[i];
                    countBlocks++;
                }
                else
                {
                    preBlockSum += A[i];
                }
            }

            return countBlocks;
        }
    }
}
