using adventofcode.utils;
using System.Linq;

namespace adventofcode.dec9
{
    public class Day9
    {
        public (long, long) GetAnswers()
        {
            var decoder = new Decoder();
            var input = ParseInput();
            var magicNumber = decoder.Decode(input, 25);

            return (magicNumber, decoder.FindRange(input, magicNumber));
        }

        private long[] ParseInput()
        {
            var fileReader = new FileReader();

            return fileReader.ReadLineByLine("assets/dec9.txt").Select(long.Parse).ToArray();
        }
    }
}
