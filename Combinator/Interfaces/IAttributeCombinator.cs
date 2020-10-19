using System.Collections.Generic;
using Task1.Attributes.Interfaces;

namespace Task1.Combinator.Interfaces
{
    public interface IAttributeCombinator
    {
        List<string> GenerateAllStringCombinations(List<IStringableAttributeType> rules);
    }
}
