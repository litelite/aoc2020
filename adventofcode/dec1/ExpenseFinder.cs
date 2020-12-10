using System;
using System.Collections.Generic;
using System.IO;

namespace adventofcode.dec1
{
    public class ExpenseFinder
    {
       public static int FindCorrect()
        {

            List<int> expenses = new List<int>();

            using (var file = File.OpenRead("assets/dec1.txt"))
            {
                using (var stream = new StreamReader(file))
                {
                    string line;
                    while((line = stream.ReadLine()) != null)
                    {
                        expenses.Add(int.Parse(line));
                    }
                }
            }

            for (var i = 0; i < expenses.Count; i++)
            {
                for (var j = i + 1; j < expenses.Count; j++)
                {
                    for (var k = j + 1; k < expenses.Count; k++)
                    {
                        var first = expenses[i];
                        var second = expenses[j];
                        var third = expenses[k];
                        if (first + second + third == 2020) return first * second * third;
                    }
                }
            }

            throw new ArgumentException("DID NOT FIND AN ANSWER");
        }
    }
}
