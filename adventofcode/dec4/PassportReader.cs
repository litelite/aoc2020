using adventofcode.utils;
using System;
using System.Collections.Generic;

namespace adventofcode.dec4
{
    public class PassportReader
    {
        private readonly FileReader _fileReader = new FileReader();

        public IEnumerable<Passport> ReadAllPassport(string file)
        {
            List<Passport> passports = new List<Passport>();
            Passport current = new Passport();

            foreach (var line in _fileReader.ReadLineByLine(file))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (!current.IsEmpty())
                    {
                        passports.Add(current);
                        current = new Passport();
                    }
                }
                else
                {
                    var fields = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    foreach (var field in fields)
                    {
                        var parts = field.Split(":", 2);
                        var key = parts[0];
                        var value = parts[1];
                        current.AddField(key, value);
                    }
                }
            }

            if(!current.IsEmpty()) passports.Add(current);

            return passports;
        }
    }
}
