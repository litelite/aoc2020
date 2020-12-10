using adventofcode.utils;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode.dec3
{
    public class PathFinder
    {
        private static readonly (int, int)[] Slopes = {
            (1, 1),
            (3, 1),
            (5, 1),
            (7, 1),
            (1, 2),
        };
        private readonly FileReader _reader;

        public PathFinder()
        {
            _reader = new FileReader();
        }

        public long NbTree()
        {
            var map = ReadMap();

            long answer = 1;
            foreach (var (right, down) in Slopes)
            {
                int x = 0;
                int nbTree = 0;

                for (int y = 0; y < map.GetRowCount(); y += down)
                {
                    if (map[x, y]) nbTree++;
                    x += right;
                }

                answer *= nbTree;
            }
         
            return answer;
        }

        private Map ReadMap()
        {
            var mapList = new List<List<bool>>();
            _reader.ReadLineByLine("assets/dec3.txt", line =>
            {
                var row = line.Select(x => x == '#').ToList();
                mapList.Add(row);
            });
            var model = new bool[mapList[0].Count, mapList.Count];
            for (var y = 0; y < mapList.Count; y++)
            {
                for (var x = 0; x < mapList[y].Count; x++)
                {
                    model[x, y] = mapList[y][x];
                }
            }

            return new Map(model);
        }
    }
}
