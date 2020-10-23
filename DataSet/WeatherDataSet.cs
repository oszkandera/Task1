﻿using System;
using System.Collections.Generic;
using System.Linq;
using Task1.DataSet.Interfaces;

namespace Task1.DataSet
{
    public class WeatherDataSet : IDataSet
    {
        public List<Tuple<string, string>> Instances => new List<Tuple<string,string>>
        {
            new Tuple<string, string>("sunny;hot;high;FALSE", "no"),
            new Tuple<string, string>("sunny;hot;high;TRUE","no"),
            new Tuple<string, string>("overcast;hot;high;FALSE","yes"),
            new Tuple<string, string>("rainy;mild;high;FALSE","yes"),
            new Tuple<string, string>("rainy;cool;normal;FALSE","yes"),
            new Tuple<string, string>("rainy;cool;normal;TRUE","no"),
            new Tuple<string, string>("overcast;cool;normal;TRUE","yes"),
            new Tuple<string, string>("sunny;mild;high;FALSE","no"),
            new Tuple<string, string>("sunny;cool;normal;FALSE","yes"),
            new Tuple<string, string>("rainy;mild;normal;FALSE","yes"),
            new Tuple<string, string>("sunny;mild;normal;TRUE","yes"),
            new Tuple<string, string>("overcast;mild;high;TRUE","yes"),
            new Tuple<string, string>("overcast;hot;normal;FALSE","yes"),
            new Tuple<string, string>("rainy;mild;high;TRUE","no")
        };

        public List<string> FindRulesInDataSet(List<string> attributeCombinations)
        {
            var rules = new HashSet<string>();
            var instancesWithoutResult = Instances.Select(x => x.Item1.ToLower());
            foreach(var instance in instancesWithoutResult)
            {
                foreach(var attributeCombination in attributeCombinations)
                {
                    if (String.IsNullOrWhiteSpace(attributeCombination)) continue;

                    if (InstanceContainsAttributeCombination(instance, attributeCombination)) rules.Add(attributeCombination);
                }
            }

            return rules.ToList();
        }

        private bool InstanceContainsAttributeCombination(string instance, string attributeCombination)
        {
            var attributesInInstance = instance.Split(';').Select(x => x.ToLower());
            var attributesInCombination = attributeCombination.Split(';');

            var attributesInCombinationCount = attributesInCombination.Count();
            var equationCounter = 0;

            foreach(var attributeInCombination in attributesInCombination)
            {
                if (attributesInInstance.Contains(attributeInCombination.ToLower())) equationCounter++;
            }

            return equationCounter == attributesInCombinationCount;
        }

        public List<Tuple<string, double>> GetSupportOfRules(List<string> rules)
        {
            var rulesWithSupport = new List<Tuple<string, double>>();

            foreach(var rule in rules)
            {
                var positiveInstanceNumber = 0;
                foreach(var instance in Instances)
                {
                    if (InstanceContainsAttributeCombination(instance.Item1, rule)) positiveInstanceNumber++;
                }

                double support = (double)positiveInstanceNumber / Instances.Count;

                rulesWithSupport.Add(new Tuple<string, double>(rule, support));

            }
            return rulesWithSupport;
        }

        public List<Tuple<string, double>> GetConfidenceOfRules(List<string> rules)
        {
            var rulesWithConfidence = new List<Tuple<string, double>>();

            foreach (var rule in rules)
            {
                var positiveInstanceNumber = 0;
                var negativeInstanceNumber = 0;
                foreach (var instance in Instances)
                {
                    if (InstanceContainsAttributeCombination(instance.Item1, rule))
                    {
                        if (instance.Item2 == "yes") positiveInstanceNumber++;
                        if (instance.Item2 == "no") negativeInstanceNumber++;
                    }
                }

                double confidence = (double)positiveInstanceNumber / (positiveInstanceNumber + negativeInstanceNumber);

                rulesWithConfidence.Add(new Tuple<string, double>(rule, confidence));
            }
            return rulesWithConfidence;
        }

        public List<Tuple<string, double, double>> GetSupportAndConfidenceOdRules(List<string> rules)
        {
            var rulesWithConfidence = new List<Tuple<string, double, double>>();

            foreach (var rule in rules)
            {
                var positiveInstanceNumber = 0;
                var negativeInstanceNumber = 0;
                foreach (var instance in Instances)
                {
                    if (InstanceContainsAttributeCombination(instance.Item1, rule))
                    {
                        if (instance.Item2 == "yes") positiveInstanceNumber++;
                        if (instance.Item2 == "no") negativeInstanceNumber++;
                    }
                }

                double confidence = (double)positiveInstanceNumber / (positiveInstanceNumber + negativeInstanceNumber);
                double support = (double)(positiveInstanceNumber + negativeInstanceNumber) / Instances.Count;
                rulesWithConfidence.Add(new Tuple<string, double, double>(rule, confidence, support));
            }
            return rulesWithConfidence;
        }
    }
}
