using System;
using System.Collections.Generic;

namespace Codility
{
    public class NumberSolitaire
    {
        public int solution(int[] A)
        {
            const int maxDistance = 6;
            var markedSquares = new Stack<int>();
            var n = A.Length;
            var result = A[0];

            var marked = 0;
            var maxInRoundIdx = 1;

            for (int square = 1; square < n; square++)
            {
                if (square - marked > maxDistance)
                {
                    marked = maxInRoundIdx;

                    if (A[markedSquares.Peek()] < 0)
                    {
                        var lastMarked = markedSquares.Pop();

                    }

                    markedSquares.Push(marked);
                    result += A[maxInRoundIdx];
                    maxInRoundIdx = marked + 1;
                    square = marked + 1;
                }

                if (square < n)
                {
                    maxInRoundIdx = A[square] >= A[maxInRoundIdx] ? square : maxInRoundIdx;

                    if (A[square] >= 0)
                    {
                        marked = square;
                        markedSquares.Push(marked);
                        result += A[square];
                        maxInRoundIdx = square + 1;
                    }   
                }
            }

            if (A[n - 1] < 0)
            {
                result += A[n - 1];
            }

            return result;
        }
    }
}
