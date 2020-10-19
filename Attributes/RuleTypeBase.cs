using System.Collections.Generic;
using System.Linq;
using Task1.Attributes.Interfaces;

namespace Task1.Attributes
{
    public class AttributeTypeBase<T> : IAttributeType<T>
    {
        public string Name { get; set; }
        public virtual T[] Values { get; set; }

        public List<string> GetStringRepresentationOfValues()
        {
            return Values.Select(x => x.ToString()).ToList();
        }
    }
}
