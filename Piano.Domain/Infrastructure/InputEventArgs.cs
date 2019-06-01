using System;

namespace Domain
{
    public class InputEventArgs : EventArgs
    {
        public InputEventArgs(int keyNumber)
        {
            KeyNumber = keyNumber;
        }

        public int KeyNumber { get; }
    }
}
