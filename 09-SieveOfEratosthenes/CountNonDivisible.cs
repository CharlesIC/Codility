namespace Codility
{
    internal class CountNonDivisible
    {
        public int[] Solution(int[] A)
        {
            var N = A.Length;
            var countNumbers = new int[(2 * N) + 1];
            var countDivisibles = new int[(2 * N) + 1];
            var countIndivisibles = new int[N];

            foreach (var x in A)
            {
                countNumbers[x]++;
            }

            for (int num = 1; num < countNumbers.Length; num++)
            {
                if (countNumbers[num] != 0)
                {
                    var pointer = num;
                    while (pointer <= 2 * N)
                    {
                        if (countNumbers[pointer] != 0)
                        {
                            countDivisibles[pointer] += countNumbers[num];
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
