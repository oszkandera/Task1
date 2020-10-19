using Task1.Rules.Interfaces;

namespace Task1.Rules
{
    public class DecisionRuleType : RuleTypeBase<bool>
    {
        public override bool[] Values => new bool[] { true, false };
    }
}
