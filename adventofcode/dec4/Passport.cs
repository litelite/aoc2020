using System.Collections.Generic;
using System.Linq;

namespace adventofcode.dec4
{
    public class Passport
    {
        private static readonly string[] RequiredFields =
        {
            "byr",
            "iyr",
            "eyr",
            "hgt",
            "hcl",
            "ecl",
            "pid",
        };
        private readonly FieldFactory _factory = new FieldFactory();
        private readonly List<IField> _fields = new List<IField>();

        public void AddField(string key, string value)
        {
            _fields.Add(_factory.CreateField(key, value));
        }

        public bool IsValid()
        {
            var receivedFields = _fields.Where(x => x.IsValid()).Select(x => x.Key);
            return !RequiredFields.Except(receivedFields).Any();
        }

        public bool IsEmpty() => !_fields.Any();

    }
}
