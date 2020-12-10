using System;
using System.Collections.Generic;
using System.IO;

namespace adventofcode.utils
{
    public class FileReader : IFileReader
    {
        public void ReadLineByLine(string path, Action<string> act)
        {
            using var file = File.OpenRead(path);
            using var stream = new StreamReader(file);

            string line;
            while ((line = stream.ReadLine()) != null)
            {
                act(line);
            }
        }

        public IEnumerable<string> ReadLineByLine(string path)
        {
            using var file = File.OpenRead(path);
            using var stream = new StreamReader(file);

            string line;
            while ((line = stream.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}
