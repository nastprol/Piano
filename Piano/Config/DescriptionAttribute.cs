using System;

namespace Piano
{
    public class DescriptionAttribute : Attribute
    {
        public string Name { get; }
        public DescriptionAttribute(string description)
        {
            Name = description;
        }
    }
}
