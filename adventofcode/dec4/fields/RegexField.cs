using System.Text.RegularExpressions;

namespace adventofcode.dec4.fields
{
    public class RegexField : IField
    {
        private readonly string _value;
        private readonly Regex _validation;

        public RegexField(string key, string value, Regex validation)
        {
            Key = key;
            _value = value;
            _validation = validation;
        }

        public string Key { get; }

        public bool IsValid()
        {
            return _validation.IsMatch(_value);
        }
    }
}
