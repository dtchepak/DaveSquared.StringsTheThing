using System;

namespace DaveSquared.StringsTheThing
{
    public class ExpressionParts
    {
        public char Delimiter { get; private set; }
        public string Remainder { get; private set; }

        public ExpressionParts(char delimiter, string remainder)
        {
            Delimiter = delimiter;
            Remainder = remainder;
        }
    }
}