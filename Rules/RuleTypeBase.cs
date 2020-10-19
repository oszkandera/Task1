﻿using System.Collections.Generic;
using System.Linq;
using Task1.Rules.Interfaces;

namespace Task1.Rules
{
    public class RuleTypeBase<T> : IRuleType<T>
    {
        public string Name { get; set; }
        public virtual T[] Values { get; set; }

        public List<string> GetStringRepresentationOfValues()
        {
            return Values.Select(x => x.ToString()).ToList();
        }
    }
}
