using System.Collections.Generic;
using System.Linq;

namespace adventofcode.dec6
{
    public class Group
    {
        private readonly List<Person> _persons = new List<Person>();

        public void AddPerson(Person person)
        {
            _persons.Add(person);
        }

        public int GetAnswerCount() => _persons.SelectMany(x => x.Answers).Distinct().Count();

        public int GetAnswersByAll() => _persons
                .SelectMany(x => x.Answers)
                .GroupBy(x => x)
                .Count(x => x.Count() == _persons.Count);


        public bool Empty => !_persons.Any();
    }
}
