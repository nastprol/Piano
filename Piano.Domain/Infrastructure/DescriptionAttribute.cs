using System;

namespace Domain.Infrastructure
{
    public class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(string description)
        {
            Name = description;
        }

        public string Name { get; }
    }
}