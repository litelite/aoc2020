using adventofcode.utils;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode.dec10
{
    public class Day10
    {
        private readonly IFileReader _fileReader;

        public Day10(IFileReader fileReader = null)
        {
            _fileReader = fileReader ?? new FileReader();
        }

        public (int, long) GetAnswers()
        {
            var chainFinder = new ChainFinder();
            var joltages = GetJoltages().ToArray();
            return (chainFinder.GetJoltDifference(joltages), chainFinder.GetArrangementCount(joltages));
        }

        private IEnumerable<int> GetJoltages() => _fileReader.ReadLineByLine("assets/dec10.txt").Select(int.Parse);
    }
}
