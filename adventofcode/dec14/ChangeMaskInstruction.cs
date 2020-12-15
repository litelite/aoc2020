namespace adventofcode.dec14
{
    class ChangeMaskInstruction : IInstruction
    {
        public Mask Mask{ get; }

        public ChangeMaskInstruction(Mask newMask)
        {
            Mask = newMask;
        }
    }
}
