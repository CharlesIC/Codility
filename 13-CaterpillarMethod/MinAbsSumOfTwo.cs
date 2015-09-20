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

                    result = Math.Min(Math.Abs(A[back] + A[front]));
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
    }
}
