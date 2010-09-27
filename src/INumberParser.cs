using System;
using System.Collections.Generic;
using System.Linq;

namespace DaveSquared.StringsTheThing
{
    public interface INumberParser
    {
        IEnumerable<int> Parse(string stringOfNumbers);
    }

    public class DelimitedNumberParser : INumberParser
    {
        public IEnumerable<int> Parse(string stringOfNumbers)
        {
            return stringOfNumbers
                .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x));
        }
    }
}