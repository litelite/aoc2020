using System;
using System.Collections.Generic;

namespace adventofcode.utils
{
    public interface IFileReader
    {
        IEnumerable<string> ReadLineByLine(string path);
        void ReadLineByLine(string path, Action<string> act);
    }
}