using System;
using System.Linq;
using System.Collections.Generic;

namespace Codility
{
    public class MinAbsSum
    {
        public int solution(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = Math.Abs(A[i]);
            }

            var sum = A.Sum();

            var numbers = new Dictionary<int, int>();
            foreach (var num in A)
            {
                if (!numbers.ContainsKey(num))
                {
                    numbers.Add(num, 0);
                }

                numbers[num]++;
            }

            var n = sum / 2 + 1;
            var sumAchievable = new int[n];
            sumAchievable[0] = 0;

            for (int i = 1; i < sumAchievable.Length; i++)
            {
                sumAchievable[i] = -1;
            }
                
            foreach (var num in numbers.Keys)
            {
                for (int trySum = 0; trySum < n; trySum++)
                {
                    if (sumAchievable[trySum] >= 0)
                    {
                        sumAchievable[trySum] = numbers[num];
                    }
                    else if (trySum >= num && sumAchievable[trySum - num] > 0)
                    {
                        sumAchievable[trySum] = sumAchievable[trySum - num] - 1;
                    }
                }
            }

            for (int halfSum = n - 1; halfSum >= 0; halfSum--)
            {
                if (sumAchievable[halfSum] >= 0)
                {
                    return sum - halfSum - halfSum;
                }
            }

            throw new Exception("Oopsie whoopsie!");
        }
    }
}
