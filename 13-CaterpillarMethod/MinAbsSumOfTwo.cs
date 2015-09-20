using System;

namespace Codility
{
    public class MinAbsSumOfTwo
    {
        public int solution(int[] A)
        {
            Array.Sort(A);

            var tail = 0;
            var head = A.Length - 1;
            var result = Math.Abs(A[tail] + A[head]);

            while (tail != head)
            {
                while (CanMoveTail(A, tail, head) || CanMoveHead(A, tail, head))
                {
                    while (CanMoveTail(A, tail, head))
                    {
                        tail++;
                    }

                    while (CanMoveHead(A, tail, head))
                    {
                        head--;
                    }

                    result = Math.Min(result, Math.Abs(A[tail] + A[head]));
                }

                if (tail != head)
                {
                    tail++;
                }

                if (tail != head)
                {
                    head--;
                }

                result = Math.Min(result, Math.Abs(A[tail] + A[head]));
            }

            return result;
        }

        private bool CanMoveTail(int[] A, int tail, int head)
        {
            if (tail < A.Length - 1)
            {
                return 
                    tail != head && Math.Abs(A[tail + 1] + A[head]) <= Math.Abs(A[tail] + A[head]);
            }

            return false;
        }

        private bool CanMoveHead(int[] A, int tail, int head)
        {
            if (head > 0)
            {
                return
                    tail != head && Math.Abs(A[tail] + A[head - 1]) <= Math.Abs(A[tail] + A[head]);
            }

            return false;
        }
    }
}
