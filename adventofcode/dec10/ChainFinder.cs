using System.Collections.Generic;
using System.Linq;

namespace adventofcode.dec10
{
    class ChainFinder
    {
        private const int MaxInterconnectDiff = 3;
        public int GetJoltDifference(IEnumerable<int> joltages)
        {
            var chain = joltages.OrderBy(x => x);
            var diffBy1 = 0;
            var diffBy3 = 0;
            var previous = 0;

            foreach (var current in chain)
            {
                var diff = current - previous;
                if (diff == 1) diffBy1++;
                else if (diff == 3) diffBy3++;

                previous = current;
            }

            diffBy3++;

            return diffBy1 * diffBy3;
        }

        public long GetArrangementCount(IEnumerable<int> joltages)
        {
            var data = joltages.OrderBy(x => x).Select(x => (jolt: x , value: long.MinValue)).ToArray();
            data[^1].value = 1;

            for (var i = data.Length - 2; i >= 0; i--)
            {
                data[i].value = data.Skip(i + 1)
                    .TakeWhile(x => x.jolt <= data[i].jolt + MaxInterconnectDiff)
                    .Sum(x => x.value);
            }

            return data.TakeWhile(x => x.jolt <= MaxInterconnectDiff).Sum(x => x.value);
        }
    }
}
