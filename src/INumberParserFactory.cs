using System;

namespace DaveSquared.StringsTheThing
{
    public interface INumberParserFactory
    {
        INumberParser CreateForDelimiter(char delimiter);
    }

    public class NumberParserFactory : INumberParserFactory
    {
        public INumberParser CreateForDelimiter(char delimiter)
        {
            return new NumberParser(delimiter);
        }
    }
}