using System.Collections.Generic;
using System.Linq;

namespace adventofcode.dec15
{
    public class NumberGame
    {
        public int FindNthSpokenNumber(IEnumerable<int> seed, int turns)
        {
            var seedArray = seed.ToArray();
            var numbers = seedArray.Take(seedArray.Length - 1)
                .Select((n, i) => (n, i))
                .ToDictionary(x => x.n, x => x.i);
            var previous = seedArray.Last();
            
            for (var i = numbers.Count + 1; i < turns; i++)
            {
                if (!numbers.TryGetValue(previous, out var lastIndex))
                {
                    numbers[previous] = i - 1;
                    previous = 0;
                }
                else
                {
                    numbers[previous] = i - 1;
                    previous = (i - lastIndex) - 1;
                }
            }

            return previous;
        }
    }
}
