using System;

namespace Piano
{

    class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(string description )
        {

        }
    }
    public enum Note
    {
        [Description("asdaad")]
        Do,
        Re,
        Mi,
        Fa,
        Sol,
        La,
        Si,
        Do_Sharp,
        Re_Sharp,
        Fa_Sharp,
        Sol_Sharp,
        La_Sharp
    }
}