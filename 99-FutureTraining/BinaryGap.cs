using System;
using System.Collections.Generic;

namespace Codility
{
    public class BinaryGap
    {
        public int solution(int N)
        {
            int x = N;
            var count = 0;
            var gap = new Stack<int>();

            var allBits = new Stack<int>();

            while (x > 0)
            {
                var bit = x % 2;
                allBits.Push(bit);

                if (bit == 1)
                {
                    if (gap.Count == 0)
                    {
                        gap.Push(1);
                    }
                    else
                    {
                        count = Math.Max(count, gap.Count - 1);
                        gap.Clear();
                        gap.Push(1);
                    }
                }
                else
                {
                    if (gap.Count > 0)
                    {
                        gap.Push(0);
                    }
                }

                x /= 2;
            }

            Console.Write("\n{0} bits: ", N);
            foreach (var bit in allBits)
            {
                Console.Write(bit);
            }

            return count;
        }

        public int solution2(int N)
        {
            int x = N;
            var count = 0;
            var currentCount = -1;

            while (x > 0)
            {
                var bit = x % 2;

                if (bit == 1)
                {
                    if (currentCount == -1)
                    {
                        currentCount = 0;
                    }
                    else
                    {
                        count = Math.Max(count, currentCount);
                        currentCount = 0;
                    }
                }
                else
                {
                    if (currentCount >= 0)
                    {
                        currentCount++;
                    }
                }

                x /= 2;
            }

            return count;
        }
    }
}
