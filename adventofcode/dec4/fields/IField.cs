namespace adventofcode.dec4
{
    public interface IField
    {
        string Key { get; }
        bool IsValid();
    }
}
