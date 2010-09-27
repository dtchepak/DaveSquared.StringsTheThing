using System.Collections.Generic;

namespace DaveSquared.StringsTheThing
{
    public interface IAdder
    {
        int Add(IEnumerable<int> theNumbers);
    }
}