namespace Task1.Attributes.Interfaces
{
    public interface IAttributeType<T> : IStringableAttributeType
    {
        string Name { get; set; }
        T[] Values { get; }
    }
}
