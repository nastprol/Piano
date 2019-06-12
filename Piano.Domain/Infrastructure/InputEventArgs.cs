using System;

namespace Domain.Infrastructure
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
