using System;

namespace Piano
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