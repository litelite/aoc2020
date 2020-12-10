using adventofcode.utils;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode.dec6
{
    public class Day6
    {
        private readonly IFileReader _fileReader;

        public Day6(IFileReader fileReader = null)
        {
            _fileReader = fileReader ?? new FileReader();
        }

        public (int,int) GetAnswers()
        {
            var groups = ReadAllGroups();

            return (groups.Sum(x => x.GetAnswerCount()), groups.Sum(x => x.GetAnswersByAll()));
        }

        private IEnumerable<Group> ReadAllGroups()
        {
            List<Group> groups = new List<Group>();
            var currentGroup = new Group();
            foreach (var line in _fileReader.ReadLineByLine("assets/dec6.txt"))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (!currentGroup.Empty)
                    {
                        groups.Add(currentGroup);
                        currentGroup = new Group();
                    }
                }
                else
                {
                    var person = new Person();
                    person.AddAnswers(line);
                    currentGroup.AddPerson(person);
                }
            }
            if(!currentGroup.Empty) groups.Add(currentGroup);
            return groups;
        }

    }
}
