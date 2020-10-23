using System;
using System.Collections.Generic;

namespace Task1.DataSet.Interfaces
{
    public interface IDataSet
    {
        List<Tuple<string, string>> Instances { get; }
        List<string> FindRulesInDataSet(List<string> attributeCombinations);
        List<Tuple<string, double>> GetSupportOfRules(List<string> rules);
        List<Tuple<string, double>> GetConfidenceOfRules(List<string> rules);
        List<Tuple<string, double, double>> GetSupportAndConfidenceOdRules(List<string> rules);
    }
}
