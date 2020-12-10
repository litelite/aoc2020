using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode.dec9
{
    public class Decoder
    {
        public long Decode(long[] input, int preambleLength)
        {
            for (var i = preambleLength; i < input.Length; i++)
            {
                if (!IsSumOfPair(input, i - preambleLength, i - 1, input[i])) return input[i];
            }

            throw new Exception("NO ANSWER");
        }

        public long FindRange(long[] input, long magicNumber)
        {
            for (var i = 0; i < input.Length; i++)
            {
                for (var j = i + 1; j < input.Length; j++)
                {
                    var range = ExtractRange(input, i, j).ToArray();
                    var sum = range.Sum();
                    if (sum == magicNumber)
                    {
                        return range.Min() + range.Max();
                    }
                    if (sum > magicNumber)
                    {
                        break;
                    }
                }
            }

            throw new Exception("NO ANSWER");
        }

        private IEnumerable<long> ExtractRange(IEnumerable<long> input, int min, int max) => input.Skip(min).Take(max - min);
     
        private bool IsSumOfPair(IReadOnlyList<long> input, int min, int max, long sum)
        {
            for (var i = min; i <= max; i++)
            {
                for (var j = i + 1; j <= max; j++)
                {
                    if (input[i] + input[j] == sum) return true;
                }
            }

            return false;
        }
    }
}
