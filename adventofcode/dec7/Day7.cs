using adventofcode.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace adventofcode.dec7
{
    public class Day7
    {
        private readonly IFileReader _fileReader;
        private readonly Regex _lineParser = new Regex(@"(.*) bags contain (.*)\.");
        private readonly Regex _childParser = new Regex(@"([0-9]+) (.+) bag[s]?");

        public Day7(IFileReader fileReader = null)
        {
            _fileReader = fileReader ?? new FileReader();
        }

        public (int, int) GetAnswers()
        {
            var graph = ParseGraph();

            var nbCanContain = graph.GetNumberOfBagThatCanContain("shiny gold");
            var capacity = graph.GetCapacityOf("shiny gold");

            return (nbCanContain, capacity);
        }

        private Graph ParseGraph()
        {
            var graph = new Graph();
            foreach (var line in _fileReader.ReadLineByLine("assets/dec7.txt"))
            {
                var match = _lineParser.Match(line);
                if(!match.Success) throw new Exception("NO MATCH");

                var bagName = match.Groups[1].Value;
                var childs = ParseChilds(match.Groups[2].Value);
                graph.Insert(bagName, childs);
            }

            return graph;
        }

        private IEnumerable<(string, int)> ParseChilds(string line)
        {
            if (line == "no other bags") return Enumerable.Empty<(string, int)>();
            var parts = line.Split(',');
            var childs = new List<(string, int)>(parts.Length);
            foreach (var part in parts)
            {
                var match = _childParser.Match(part);
                if(!match.Success) throw new ArgumentException("NO MATCH");
                var nbBags = int.Parse(match.Groups[1].Value);
                var bagName = match.Groups[2].Value;
                childs.Add((bagName, nbBags));
            }

            return childs;
        }
    }
}
