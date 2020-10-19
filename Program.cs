using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Task1.Rules;
using Task1.Rules.Interfaces;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var rules = new List<IStringableRuleType>
            {
                new CollectionRuleType<string> { Name = "Outlook", Values = new string[] { "Sanny", "Overcast", "Rainy" } },
                new CollectionRuleType<string> { Name = "Temperature", Values = new string[] { "Hot", "Mild", "Cold" } },
                new CollectionRuleType<string> { Name = "Humidity", Values = new string[] { "High", "Normal" } },
                new DecisionRuleType { Name = "Windy" }
            };

            //byte x = 3;

            //var b = new BitArray(new byte[] { x });

            //var k = b.Get(1);

            var ruleCombinator = new RuleCombinator();

            var ruleCombinations = ruleCombinator.GenerateAllStringCombinations(rules);

            //var x = ruleCombinator.PermutationOf<string>(new HashSet<string> { "Sanny", "Overcast", "Rainy", "Hot", "Mild", "Cold", "High", "Normal", "True", "False" });
        }
    }
}
