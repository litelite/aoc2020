namespace adventofcode.dec15
{
    public class Day15
    {
        
        public (int, int) GetAnswers()
        {
            var seed = new[] {8, 11, 0, 19, 1, 2};
            var game = new NumberGame();
            return (game.FindNthSpokenNumber(seed, 2020), 0);
        }
    }
}
