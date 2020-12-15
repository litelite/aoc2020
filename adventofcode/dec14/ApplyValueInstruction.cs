namespace adventofcode.dec14
{
    class ApplyValueInstruction : IInstruction
    {
        public long Address { get; }
        public long Value { get; }

        public ApplyValueInstruction(int address, long value)
        {
            Address = address;
            Value = value;
        }


    }
}
