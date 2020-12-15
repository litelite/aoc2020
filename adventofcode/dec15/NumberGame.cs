using System.Collections.Generic;
using System.Linq;

namespace adventofcode.dec15
{
    public class NumberGame
    {
        public int FindNthSpokenNumber(IEnumerable<int> seed, int turns)
        {
            var numbers = new List<int>(seed) {Capacity = turns};
            turns--;
            for(var i = numbers.Count - 1; i < turns; i++)
            {
                var lastIndex = numbers.LastIndexOf(numbers[i], i - 1);
                if (lastIndex == -1)
                {
                    numbers.Add(0);
                }
                else
                {
                    numbers.Add(i - lastIndex);
                }
            }

            return numbers.Last();
        }
    }
}
