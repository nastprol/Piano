using System.Collections.Generic;

namespace Domain
{
    public class InputControlSettings : IInputControlSettings
    {
        private readonly Dictionary<string, IInputControl> controls = new Dictionary<string, IInputControl>();

        private readonly GameSettings settings;

        public InputControlSettings(IInputControl[] controls, GameSettings settings)
        {
            this.settings = settings;

            foreach (var control in controls)
                this.controls[control.GetType().Name] = control;
        }

        public IInputControl GetInputControlClass()
        {
            return controls[settings.InputTypeName];
        }
    }
}