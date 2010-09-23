using System;

namespace DaveSquared.StringsTheThing
{
    public interface IExpressionPartsParser
    {
        ExpressionParts Parse(string expression);
    }

    public class ExpressionPartsParser : IExpressionPartsParser
    {
        public ExpressionParts Parse(string expression)
        {
            if (!expression.StartsWith("//")) return GetExpressionUsingDefaultDelimiter(expression);
            return GetPartsWithCustomDelimiter(expression);
        }

        ExpressionParts GetPartsWithCustomDelimiter(string expression)
        {
            var delimiter = expression[2];
            var remainder = expression.Substring(4);
            return CreateParts(delimiter, remainder);
        }

        ExpressionParts GetExpressionUsingDefaultDelimiter(string expression)
        {
            const char defaultDelimiter = ',';
            return CreateParts(defaultDelimiter, expression);
        }

        ExpressionParts CreateParts(char delimiter, string remainder)
        {
            return new ExpressionParts(delimiter, remainder);
        }
    }
}