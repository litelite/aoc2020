namespace adventofcode.dec3
{
    public class Map
    {
        private readonly bool[,] _model;

        public Map(bool[,] model)
        {
            _model = model;
        }

        public bool this[int x, int y]
        {
            get
            {
                var index = x % _model.GetLength(0);

                return _model[index, y];
            }
        }

        public int GetRowCount()
        {
            return _model.GetLength(1);
        }
    }
}
