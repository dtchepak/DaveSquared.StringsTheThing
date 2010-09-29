namespace DaveSquared.StringsTheThing
{
    public interface IExpressionPartsParser
    {
        ExpressionParts Parse(string expression);
    }
}