namespace adventofcode.dec4.fields
{
    public class NoValidationField : IField
    {

        public NoValidationField(string key)
        {
            Key = key;
        }


        public string Key { get; }

        public bool IsValid()
        {
            return true;
        }
    }
}
