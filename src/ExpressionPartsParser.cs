namespace DaveSquared.StringsTheThing
{
    public class ExpressionPartsParser : IExpressionPartsParser
    {
        public ExpressionParts Parse(string expression)
        {
            if (!expression.StartsWith("//")) return GetPartsWithDefaultDelimiter(expression);
            return GetPartsWithCustomDelimiter(expression);
        }

        ExpressionParts GetPartsWithCustomDelimiter(string expression)
        {
            var delimiter = expression[2];
            var remainder = expression.Substring(4);
            return new ExpressionParts(delimiter, remainder);
        }

        ExpressionParts GetPartsWithDefaultDelimiter(string expression)
        {
            return new ExpressionParts(',', expression);
        }
    }
}