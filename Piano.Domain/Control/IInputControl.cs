using System;

namespace Domain
{
    public interface IInputControl
    {
        int? MakeInput(EventArgs e);
        void Subscribe(Controller controller);
        void Unsubscribe(Controller controller);
    }
}