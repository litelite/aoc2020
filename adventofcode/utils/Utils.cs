using System.Collections.Generic;
using System.Linq;

namespace adventofcode.utils
{
    public static class Utils
    {
        public static T[,] To2DArray<T>(List<List<T>> input)
        {
            var rows = input.Count();
            var columns = input.First().Count();
            var output = new T[rows, columns];

            for (var i = 0; i < input.Count; i++)
            {
                for (var j = 0; j < input[i].Count; j++)
                {
                    output[i, j] = input[i][j];
                }
            }

            return output;
        }
    }
}
