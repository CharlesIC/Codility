using System;

namespace Codility
{
    public class BinaryGap
    {
        public int solution(int N)
        {
            int x = N;
            var count = 0;
            var currentCount = 0;

            // Skip initial zeros
            while (x > 0 && x % 2 == 0)
            {
                x /= 2;
            }

            while (x > 0)
            {
                if (x % 2 == 1)
                {
                    if (currentCount != 0)
                    {
                        count = Math.Max(count, currentCount);
                        currentCount = 0;
                    }
                }
                else
                {
                    currentCount++;
                }

                x /= 2;
            }

            return count;
        }

        public int solution2(int N)
        {
            int x = N;
            int count = 0;
            var currentCount = 0;

            // Skip initial zeros
            while ((x & 1) == 0)
            {
                x = x >> 1;
            }

            while (x > 0)
            {
                if ((x & 1) == 1)
                {
                    if (currentCount != 0)
                    {
                        count = Math.Max(count, currentCount);
                        currentCount = 0;
                    }
                }
                else
                {
                    currentCount++;
                }

                x = x >> 1;
            }

            return count;
        }
    }
}
