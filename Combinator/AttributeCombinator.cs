using System.Collections.Generic;
using Task1.Attributes.Interfaces;
using Task1.Combinator.Interfaces;

namespace Task1.Combinator
{
    public class AttributeCombinator : IAttributeCombinator
    {
        public List<string> GenerateAllStringCombinations(List<IStringableAttributeType> rules)
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
                    var newValue = $"{combination};{value}".Trim(';');
                    newCombinations.Add(newValue);
                }
            }
            return newCombinations;
        }
    }
}
