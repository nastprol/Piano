using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano
{
    public class InputControlSettings
    {
        private readonly Dictionary<string, IInputControl> controls = new Dictionary<string, IInputControl>();
        public IInputControl GetInputControlClass() => controls[settings.InputTypeName];

        private readonly GameSettings settings;

        public InputControlSettings(IInputControl[] controls, GameSettings settings)
        {
            this.settings = settings;

            foreach (var l in controls)
                this.controls[l.GetType().Name] = l;
        }
    }
}
