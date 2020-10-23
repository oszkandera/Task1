using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task1.Attributes;
using Task1.Attributes.Interfaces;
using Task1.Combinator;
using Task1.DataSet;
using Task1.Exporter;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var basePath = @"C:\Users\Ondra\Desktop";

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
            var supportWithConfidence = dataSet.GetSupportAndConfidenceOdRules(rules);

            Print(supportWithConfidence);
        }

        private static void Print(List<Tuple<string, double, double>> data)
        {
            Console.WriteLine("{0,-35}{1, -20}{2}", "Rule", "Confidence", "Support");
            foreach(var line in data)
            {
                Console.WriteLine("{0,-35}{1, -20}{2}", line.Item1, line.Item2, line.Item3);
            }
        }
    }
}
