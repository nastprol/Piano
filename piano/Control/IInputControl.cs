using System;
using System.Windows.Forms;

namespace Piano
{
    public interface IInputControl
    {
        int InputValue { get; } //Producer передать делегат в консируктор
        bool MakeInput(EventArgs e); //передать делегат в консируктор
        void Subscribe(Controller controller); //убрать Form 
    }
}