using System.Collections.Generic;
using System.Linq;

namespace adventofcode.dec6
{
    public class Person
    {
        private readonly HashSet<char> _answers = new HashSet<char>();

        public void AddAnswers(IEnumerable<char> answers)
        {
            foreach (var answer in answers.Distinct())
            {
                _answers.Add(answer);
            }
        }

        public IEnumerable<char> Answers => _answers;
    }
}
