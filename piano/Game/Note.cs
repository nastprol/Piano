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

    public enum Note
    {
        [Description("C")] Do,
        [Description("D")] Re,
        [Description("E")] Mi,
        [Description("F")] Fa,
        [Description("G")] Sol,
        [Description("A")] La,
        [Description("B")] Si,
        [Description("C#")] Do_Sharp,
        [Description("D#")] Re_Sharp,
        [Description("F#")] Fa_Sharp,
        [Description("G#")] Sol_Sharp,
        [Description("A#")] La_Sharp
    }
}