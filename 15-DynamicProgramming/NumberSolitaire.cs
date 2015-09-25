using System;
using System.Linq;
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
            markedSquares.Push(marked);

            var maxInRoundIdx = 1;

            for (int square = 1; square < n; square++)
            {
                if (square - marked > maxDistance)
                {
                    marked = maxInRoundIdx;

                    if (markedSquares.Count > 1 && A[markedSquares.Peek()] < 0)
                    {
                        var lastMarked = markedSquares.Pop();

                        if (marked - markedSquares.Peek() <= maxDistance)
                        {
                            result -= A[lastMarked];
                        }
                        else
                        {
                            markedSquares.Push(lastMarked);
                        }
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
                markedSquares.Push(n - 1);
            }

            Console.Write("\nSelected:");
            foreach (var square in markedSquares)
            {
                Console.Write("{0} ", square);
            }
            Console.WriteLine();

            return result;
        }

        public int solution2(int[] A)
        {
            const int d = 6;
            var n = A.Length;

            var maxScore = new int[d];
            maxScore[0] = A[0];

            for (int i = 1; i < maxScore.Length; i++)
            {
                maxScore[i] = int.MinValue;
            }


            for (int p = 1; p < n; p++)
            {
                maxScore[p % d] = maxScore.Max() + A[p];
            }

            return maxScore[(n - 1) % d];
        }
    }
}
