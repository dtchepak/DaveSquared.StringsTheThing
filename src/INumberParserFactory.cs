using System;

namespace DaveSquared.StringsTheThing
{
    public interface INumberParserFactory
    {
        INumberParser CreateWithDelimiter(char delimiter);
    }

    public class NumberParserFactory : INumberParserFactory
    {
        public INumberParser CreateWithDelimiter(char delimiter)
        {
            return new DelimitedNumberParser(delimiter);
        }
    }
}