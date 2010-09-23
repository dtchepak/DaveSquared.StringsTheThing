using System;
using System.Collections.Generic;
using System.Linq;

namespace DaveSquared.StringsTheThing
{
    public interface IAdder
    {
        int Add(IEnumerable<int> numbers);
    }

    public class Adder : IAdder
    {
        public int Add(IEnumerable<int> numbers)
        {
            return numbers.Sum();
        }
    }
}