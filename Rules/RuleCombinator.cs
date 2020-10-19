using System.Collections;
using System.Collections.Generic;
using Task1.Rules.Interfaces;

namespace Task1.Rules
{
    public class RuleCombinator : IRuleCombinator
    {
        public List<string> GenerateAllStringCombinations(List<IStringableRuleType> rules)
        {
            var referenceEmptyString = string.Empty;
            var combinations = new List<string>() { referenceEmptyString };
            foreach(var rule in rules)
            {
                var values = rule.GetStringRepresentationOfValues();
                var newCombinations = Combine(combinations, values);
                combinations.AddRange(newCombinations);
            }

            return combinations;
        }

        private List<string> Combine(List<string> combinations, List<string> values)
        {
            var newCombinations = new List<string>();
            foreach (var combination in combinations)
            {
                foreach (var value in values)
                {
                    newCombinations.Add($"{combination};{value}");
                }
            }
            return newCombinations;
        }
    }
}
