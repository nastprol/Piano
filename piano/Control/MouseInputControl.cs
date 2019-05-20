using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Piano
{
    public class MouseInputControl : IInputControl
    {
        private readonly IReadOnlyDictionary<(Point topLeft, Point bottomRight), int> controlLocations;
        private bool answerInput;

        public MouseInputControl(VisualizationSettings settings)
        {
            controlLocations = settings.ControlTools;
        }

        public int InputValue { get; private set; }

        public void Subscribe(Form form, Controller controller)
        {
            form.Click += controller.MakeStep;
        }

        public bool MakeInput(EventArgs e)
        {
            var ev = (MouseEventArgs) e;
            if (ev.Button == MouseButtons.Right)
                return answerInput;
            var location = ev.Location;
            foreach (var coords in controlLocations)
            {
                var clickX = location.X;
                var clickY = location.Y;
                var (topLeft, bottomRight) = coords.Key;
                if (topLeft.X >= clickX || clickX >= bottomRight.X || topLeft.Y >= clickY || clickY >= bottomRight.Y)
                    continue;
                InputValue = coords.Value;
                answerInput = true;
                return answerInput;
            }

            answerInput = false;
            return answerInput;
        }
    }
}