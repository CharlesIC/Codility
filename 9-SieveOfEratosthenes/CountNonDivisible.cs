namespace Practice
{
    using System.Collections.Generic;

    internal class CountNonDivisible
    {
        public int[] Solution(int[] A)
        {
            var N = A.Length;
            var numbers = new int[(2 * N) + 1];
            var countDivisibles = new int[(2 * N) + 1];
            var countIndivisibles = new int[N];

            foreach (var x in A)
            {
                numbers[x]++;
            }

            for (int num = 1; num < numbers.Length; num++)
            {
                if (numbers[num] != 0)
                {
                    var pointer = num;
                    while (pointer <= 2 * N)
                    {
                        if (numbers[pointer] != 0)
                        {
                            countDivisibles[pointer] += numbers[num];
                        }

                        pointer += num;
                    }
                }
            }

            for (int i = 0; i < N; i++)
            {
                countIndivisibles[i] = N - countDivisibles[A[i]];
            }

            return countIndivisibles;
        }
    }
}
