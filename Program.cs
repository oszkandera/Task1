using System.Collections.Generic;
using Task1.Attributes;
using Task1.Attributes.Interfaces;
using Task1.Combinator;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var rules = new List<IStringableAttributeType>
            {
                new CollectionAttributeType<string> { Name = "Outlook", Values = new string[] { "Sanny", "Overcast", "Rainy" } },
                new CollectionAttributeType<string> { Name = "Temperature", Values = new string[] { "Hot", "Mild", "Cold" } },
                new CollectionAttributeType<string> { Name = "Humidity", Values = new string[] { "High", "Normal" } },
                new DecisionAttributeType { Name = "Windy" }
            };

            
            var ruleCombinator = new AttributeCombinator();

            var ruleCombinations = ruleCombinator.GenerateAllStringCombinations(rules);

        }
    }
}
