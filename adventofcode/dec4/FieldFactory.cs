using adventofcode.dec4.fields;
using System;
using System.Text.RegularExpressions;

namespace adventofcode.dec4
{
    public class FieldFactory
    {
        private static readonly Regex ColorRegex = new Regex("^#[0-9,a-z]{6}$", RegexOptions.Compiled);
        private static readonly Regex PassportNumberRegex = new Regex("^[0-9]{9}$", RegexOptions.Compiled);

        public IField CreateField(string key, string value)
        {
            switch (key)
            {
                case "byr":
                    return new IntField(key, value, 1920, 2002);
                case "iyr":
                    return new IntField(key, value, 2010, 2020);
                case "eyr":
                    return new IntField(key, value, 2020, 2030);
                case "hgt":
                    return new IntUnitField(key, value, new IntUnitField.UnitBound("cm", 150, 193),
                                                        new IntUnitField.UnitBound("in", 59, 76));
                case "hcl":
                    return new RegexField(key, value, ColorRegex);
                case "ecl":
                    return new EnumField(key, value, "amb", "blu", "brn", "gry", "grn", "hzl", "oth");
                case "pid":
                    return new RegexField(key, value, PassportNumberRegex);
                case "cid":
                    return new NoValidationField(key);
                default:
                    throw new NotSupportedException($"field key {key} is not supported");
            }
        }
    }
}
