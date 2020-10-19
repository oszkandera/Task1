namespace Task1.Rules.Interfaces
{
    public interface IRuleType<T> : IStringableRuleType
    {
        string Name { get; set; }
        T[] Values { get; }
    }
}
