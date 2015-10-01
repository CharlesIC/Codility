using System;
using System.Linq;
using System.Collections.Generic;

namespace Codility
{
    public class OddOccurrencesInArray
    {
        public int solution(int[] A)
        {
            var elements = new HashSet<int>();

            foreach (var num in A)
            {
                if (elements.Contains(num))
                {
                    elements.Remove(num);
                }
                else
                {
                    elements.Add(num);
                }
            }

            return elements.Single();
        }
    }
}
