using System.Collections.Generic;

namespace Task1.Attributes.Interfaces
{
    public interface IStringableAttributeType
    {
        List<string> GetStringRepresentationOfValues();
    }
}
