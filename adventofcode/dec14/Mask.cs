using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode.dec14
{
    class Mask
    {
        private long _forceOnMask;
        private long _forceOffMask = ~0L;
        private int[] _floatingBits;

        public Mask(string mask)
        {
            if (mask.Length != 36) throw new ArgumentException("WRONG MASK LENGTH");
            var maskArray = mask.Reverse().ToArray();
            var floatingBits = new List<int>();
            for (var i = 0; i < maskArray.Length; i++)
            {
                switch (maskArray[i])
                {
                    case '1':
                        _forceOnMask |= 1L << i;
                        break;
                    case '0':
                        _forceOffMask &= ~(1L << i);
                        break;
                    case 'X':
                        floatingBits.Add(i);
                        break;
                    default:
                        throw new ArgumentException("INVALID MASK");
                }
            }

            _floatingBits = floatingBits.ToArray();
        }

        public long Apply(long input)
        {
            return (input | _forceOnMask) & _forceOffMask;
        }

        public IEnumerable<long> GetPossibleAddresses(long baseAddress)
        {
            return _floatingBits.Aggregate(new[] { baseAddress | _forceOnMask } as IEnumerable<long>,
                (acc, curr) => acc.SelectMany(x => new[] 
                {
                    x & ~(1L << curr), 
                    x | 1L << curr,
                }));
        }
    }
}
