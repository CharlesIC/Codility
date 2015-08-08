using System;
using System.Collections.Generic;

namespace Practice
{
    public class NailsArraysOnly
    {
        public int Solution(int[] A, int[] B, int[] C)
        {
            var nailIndex = GetSortedNails(C);
            var result = -1;

            for (int i = 0; i < A.Length; i++)
            {
                result = FindFirstNailIndex(A[i], B[i], C, nailIndex, result);

                if (result == -1)
                {
                    return -1;
                }
            }

            return result + 1;
        }

        private int FindFirstNailIndex(int plankBegin, int plankEnd, int[] nails, int[] nailIndex, int preResult)
        {
            var firstNailOrder = GetFirstNailOrder(plankBegin, plankEnd, nails, nailIndex);

            // Can't find a nail that could nail the plank
            if (firstNailOrder == -1)
            {
                return -1;
            }

            var bestNailIdx = FindBestNailForPlank(plankEnd, firstNailOrder, nails, nailIndex, preResult);

            return bestNailIdx;
        }

        private int GetFirstNailOrder(int plankBegin, int plankEnd, int[] nails, int[] nailIndex)
        {
            var firstNailOrder = -1;

            var nailOrderLower = 0;
            var nailOrderUpper = nailIndex.Length - 1;
            var nailOrderMid = 0;

            // Search by position :: Find the first nail
            // which is between plankBegin and plankEnd
            // (i.e. has the lowest acceptable position)
            while (nailOrderLower <= nailOrderUpper)
            {
                nailOrderMid = (nailOrderLower + nailOrderUpper) / 2;
                var positionMid = nails[nailIndex[nailOrderMid]];

                if (positionMid < plankBegin)
                {
                    nailOrderLower = nailOrderMid + 1;
                }
                else
                {
                    nailOrderUpper = nailOrderMid - 1;

                    if (positionMid <= plankEnd)
                    {
                        firstNailOrder = nailOrderMid;
                    }
                }
            }

            return firstNailOrder;
        }

        private int FindBestNailForPlank(int plankEnd, int firstNailOrder, int[] nails, int[] nailIndex, int preResult)
        {
            var bestNailIdx = nailIndex[firstNailOrder];

            // Search by index :: Linearly search all qualifying
            // nails and find the one that is used the earliest
            // (i.e. has the lowest index)
            var nailOrder = firstNailOrder + 1;
            while (nailOrder < nailIndex.Length)
            {
                if (nails[nailIndex[nailOrder]] > plankEnd)
                {
                    break;
                }

                bestNailIdx = Math.Min(bestNailIdx, nailIndex[nailOrder]);

                nailOrder++;

                // The current result won't influence the overall result
                // because some other plank needs a nail used later than
                // the best nail for the current one
                if (preResult >= bestNailIdx)
                {
                    return preResult;
                }
            }

            return Math.Max(bestNailIdx, preResult);
        }

        private int[] GetSortedNails(int[] nails)
        {
            var nailIndex = new int[nails.Length];

            for (int i = 0; i < nails.Length; i++)
            {
                nailIndex[i] = i;
            }

            var nailCompare = Comparer<int>.Create(new Comparison<int>((x, y) =>
                    {
                        if (nails[x] == nails[y])
                        {
                            return x - y;
                        }
                        return nails[x] - nails[y];
                    }));

            Array.Sort(nailIndex, nailCompare);

            return nailIndex;
        }

        private struct Nail
        {
            public int index;
            public int position;
        }
    }
}
