namespace adventofcode.dec4.fields
{
    public class IntField : IField
    {
        private readonly string _value;
        private readonly int _min;
        private readonly int _max;

        public IntField(string key, string value, int min, int max)
        {
            Key = key;
            _value = value;
            _min = min;
            _max = max;
        }

        public string Key { get; }

        public bool IsValid()
        {
            if (int.TryParse(_value, out var intValue))
            {
                return intValue >= _min && intValue <= _max;
            }

            return false;
        }
    }
}
