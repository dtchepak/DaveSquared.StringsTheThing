using System;
using System.Collections.Generic;
using System.Linq;

namespace DaveSquared.StringsTheThing
{
    public interface INumberParser
    {
        IEnumerable<int> Parse(string expression);
    }

    public class DelimitedNumberParser : INumberParser
    {
        public IEnumerable<int> Parse(string expression)
        {
            return expression
                .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x));
        }
    }
}