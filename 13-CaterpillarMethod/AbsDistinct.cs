using System;
using System.Linq;
using System.Collections.Generic;

namespace Codility
{
    public class AbsDistinct
    {
        public int Solution(int[] A)
        {
            var distinctAbsValues = new HashSet<int>();

            foreach (var value in A)
            {
                var absValue = 
                    value == Int32.MinValue ? 
                    value : 
                    Math.Abs(value);

                if (!distinctAbsValues.Contains(absValue))
                {
                    distinctAbsValues.Add(absValue);
                }
            }

            return distinctAbsValues.Count;
        }

        public int Solution2(int[] A)
        {
            return A.Select(x => x == int.MinValue ? x : Math.Abs(x)).Distinct().Count();
        }
    }
}
