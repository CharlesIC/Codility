using System;
using System.Collections.Generic;

namespace Practice
{
    public class DistinctValues
    {
        public int Solution(int[] A)
        {
            var counter = new HashSet<int>();

            foreach (var number in A)
            {
                if (!counter.Contains(number))
                {
                    counter.Add(number);
                }
            }

            return counter.Count;
        }
    }
}

