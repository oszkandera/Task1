using System.Collections.Generic;

namespace Task1.Rules.Interfaces
{
    public interface IStringableRuleType
    {
        List<string> GetStringRepresentationOfValues();
    }
}
