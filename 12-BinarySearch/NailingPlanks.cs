using System;
using System.Linq;
using System.Collections.Generic;

namespace Codility
{
    public class NailingPlanks
    {
        public int Solution(int[] A, int[] B, int[] C)
        {
            var sortedNails = SortNails(C);
            var result = -1;

            for (int i = 0; i < A.Length; i++)
            {
                // Find a nail for the current plank
                result = FindFirstNail(A[i], B[i], sortedNails, result);

                if (result == -1)
                {
                    return -1;
                }
            }

            return result + 1;
        }

        private int FindFirstNail(int plankBegin, int plankEnd, SortedSet<Tuple<int, int>> sortedNails, int preResult)
        {
            var firstNailOrder = GetFirstNailOrder(plankBegin, plankEnd, sortedNails);

            // Can't find a nail that could nail the plank
            if (firstNailOrder == -1)
            {
                return -1;
            }

            var bestNailIdx = FindBestNailForPlank(plankEnd, firstNailOrder, sortedNails, preResult);

            return bestNailIdx;
        }

        private int GetFirstNailOrder(int plankBegin, int plankEnd, SortedSet<Tuple<int, int>> sortedNails)
        {
            var firstNailOrder = -1;

            var nailOrderLower = 0;
            var nailOrderUpper = sortedNails.Count - 1;
            var nailOrderMid = 0;

            // Search by position :: Find the first nail
            // which is between plankBegin and plankEnd
            // (i.e. has the lowest acceptable position)
            while (nailOrderLower <= nailOrderUpper)
            {
                nailOrderMid = (nailOrderLower + nailOrderUpper) / 2;
                var positionMid = GetNailPosition(sortedNails, nailOrderMid);

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

        private int FindBestNailForPlank(int plankEnd, int firstNailOrder, SortedSet<Tuple<int, int>> sortedNails, int preResult)
        {
            var bestNailIdx = GetNailIndex(sortedNails, firstNailOrder);

            // Search by index :: Linearly search all qualifying
            // nails and find the one that is used the earliest
            // (i.e. has the lowest index)
            var nailOrder = firstNailOrder + 1;
            while (nailOrder < sortedNails.Count)
            {
                if (GetNailPosition(sortedNails, nailOrder) > plankEnd)
                {
                    break;
                }

                bestNailIdx = Math.Min(
                    bestNailIdx,
                    GetNailIndex(sortedNails, nailOrder));

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

        private SortedSet<Tuple<int, int>> SortNails(int[] nails)
        {
            var sortedNails = new SortedSet<Tuple<int,int>>();

            for (int i = 0; i < nails.Length; i++)
            {
                sortedNails.Add(new Tuple<int, int>(nails[i], i));
            }

            return sortedNails;
        }

        private int GetNailPosition(SortedSet<Tuple<int,int>> sortedNails, int nailOrder)
        {
            return sortedNails.ElementAt(nailOrder).Item1;
        }

        private int GetNailIndex(SortedSet<Tuple<int,int>> sortedNails, int nailOrder)
        {
            return sortedNails.ElementAt(nailOrder).Item2;
        }
    }
}
