using System;

namespace Codility
{
    public class MinAbsSumOfTwo
    {
        public int solution(int[] A)
        {
            Array.Sort(A);

            var back = 0;
            while (back < A.Length - 1 && Math.Abs(A[back + 1]) <= Math.Abs(A[back]))
            {
                back++;
            }

            var front = back;
            var result = Math.Abs(A[back] + A[front]);

            while (back > 0 && front < A.Length - 1)
            {
                while (CanMoveLeft(A, back, front) || CanMoveRight(A, back, front))
                {
                    while (CanMoveLeft(A, back, front))
                    {
                        back--;
                    }

                    while (CanMoveRight(A, back, front))
                    {
                        front++;
                    }

                    result = Math.Min(result, Math.Abs(A[back] + A[front]));
                }

                if (back > 0)
                {
                    back--;
                }

                if (front < A.Length - 1)
                {
                    front++;
                }
            }

            return Math.Min(result, Math.Abs(A[back] + A[front]));
        }

        private bool CanMoveLeft(int[] A, int back, int front)
        {
            if (back > 0)
            {
                return Math.Abs(A[back - 1] + A[front]) <= Math.Abs(A[back] + A[front]);
            }

            return false;
        }

        private bool CanMoveRight(int[] A, int back, int front)
        {
            if (front < A.Length - 1)
            {
                return Math.Abs(A[back] + A[front + 1]) <= Math.Abs(A[back] + A[front]);
            }

            return false;
        }

        public int solution2(int[] A)
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
