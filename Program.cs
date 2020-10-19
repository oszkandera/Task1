using System.Collections.Generic;
using Task1.Attributes;
using Task1.Attributes.Interfaces;
using Task1.Combinator;
using Task1.DataSet;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var attributes = new List<IStringableAttributeType>
            {
                new CollectionAttributeType<string> { Name = "Outlook", Values = new string[] { "Sunny", "Overcast", "Rainy" } },
                new CollectionAttributeType<string> { Name = "Temperature", Values = new string[] { "Hot", "Mild", "Cool" } },
                new CollectionAttributeType<string> { Name = "Humidity", Values = new string[] { "High", "Normal" } },
                new DecisionAttributeType { Name = "Windy" }
            };

            
            var attributeCombinator = new AttributeCombinator();

            var attributeCombinations = attributeCombinator.GenerateAllStringCombinations(attributes);

            var dataSet = new WeatherDataSet();

            var rules = dataSet.FindRulesInDataSet(attributeCombinations);

            var support = dataSet.GetSupportOfRules(rules);
            var confidence = dataSet.GetConfidenceOfRules(rules);
        }
    }
}
