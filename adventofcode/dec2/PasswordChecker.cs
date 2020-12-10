using System.IO;

namespace adventofcode.dec2
{
    public class PasswordChecker
    {
        public int GetNbValidPasswords()
        {
            using (var file = File.OpenRead("assets/dec2.txt"))
            {
                using (var stream = new StreamReader(file))
                {
                    string line;
                    int nbValidPasswords = 0;
                    while((line = stream.ReadLine()) != null)
                    {
                        if (Line.Parse(line).IsValid()) nbValidPasswords++;
                    }

                    return nbValidPasswords;
                }
            }
        }
    }
}
