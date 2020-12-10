using System.Linq;

namespace adventofcode.dec4.fields
{
    public class EnumField : IField
    {
        private readonly string _value;
        private readonly string[] _acceptedValues;

        public EnumField(string key, string value, params string[] acceptedValues)
        {
            Key = key;
            _value = value;
            _acceptedValues = acceptedValues;
        }


        public string Key { get; }

        public bool IsValid()
        {
            return _acceptedValues.Contains(_value);
        }
    }
}
