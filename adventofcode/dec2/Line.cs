using System;

namespace adventofcode.dec2
{
    public class Line
    {
        private int First { get; set; }
        private int Second { get; set; }
        private char SearchedChar { get; set; }
        private string Password { get; set; }

        public static Line Parse(string data)
        {
            var strBound = data.Substring(0, data.IndexOf(' '));
            var boundParts = strBound.Split('-', 2);
            if(boundParts.Length != 2) throw new ArgumentException("Invalid bound in line " + data);
            var first = int.Parse(boundParts[0]);
            var second = int.Parse(boundParts[1]);
            var searchedChar = data.Substring(data.IndexOf(':') - 1, 1);
            var password = data.Substring(data.IndexOf(':') + 2);
            return new Line
            {
                First = first,
                Second = second,
                SearchedChar = searchedChar[0],
                Password = password,
            };
        }

        public bool IsValid()
        {
            char firstChar = '\0';
            char secondChar = '\0';
            if (Password.Length >= First) firstChar = Password[First - 1];
            if (Password.Length >= Second) secondChar = Password[Second - 1];

            return firstChar == SearchedChar ^ secondChar == SearchedChar;
        }
    }
}
