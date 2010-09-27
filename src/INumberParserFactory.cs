namespace DaveSquared.StringsTheThing
{
    public interface INumberParserFactory
    {
        INumberParser CreateWithDelimiter(char delimiter);
    }
}