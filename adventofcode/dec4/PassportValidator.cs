using System.Linq;

namespace adventofcode.dec4
{
    public class PassportValidator
    {
        public int NbValidPassport()
        {
            var passports = new PassportReader().ReadAllPassport("assets/dec4.txt");
            return passports.Count(x => x.IsValid());
        }
    }
}
