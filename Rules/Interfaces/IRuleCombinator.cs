using System.Collections.Generic;

namespace Task1.Rules.Interfaces
{
    public interface IRuleCombinator
    {
        List<string> GenerateAllStringCombinations(List<IStringableRuleType> rules);
    }
}
