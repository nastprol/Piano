using System;

namespace Domain
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