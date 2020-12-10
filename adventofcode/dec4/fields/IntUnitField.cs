using System.Linq;
using System.Text.RegularExpressions;

namespace adventofcode.dec4.fields
{
    public class IntUnitField : IField
    {
        private readonly string _value;
        private readonly UnitBound[] _unitBounds;
        private static readonly Regex Parser = new Regex("^([0-9]+)([a-z]+)$", RegexOptions.Compiled);

        public class UnitBound
        {
            public string Unit { get; }
            public int Min { get; }
            public int Max { get; }

            public UnitBound(string unit, int min, int max)
            {
                Unit = unit;
                Min = min;
                Max = max;
            }
        }

        public IntUnitField(string key, string value, params UnitBound[] unitBounds)
        {
            Key = key;
            _value = value;
            _unitBounds = unitBounds;
        }

        public string Key { get; }
        public bool IsValid()
        {
            var match = Parser.Match(_value);
            if (!match.Success) return false;
            if (!int.TryParse(match.Groups[1].Value, out var value)) return false;

            var unit = match.Groups[2].Value;
            var bounds = _unitBounds.SingleOrDefault(x => x.Unit == unit);
            return value >= bounds?.Min && value <= bounds?.Max;
        }
    }
}
