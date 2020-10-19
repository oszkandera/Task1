using Task1.Attributes;

namespace Task1.Attributes
{
    public class DecisionAttributeType : AttributeTypeBase<bool>
    {
        public override bool[] Values => new bool[] { true, false };
    }
}
