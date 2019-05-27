using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Piano.Control;

namespace Piano
{
    [Description("Управление мышкой")]
    public class MouseInputControl : IInputControl
    {
        private readonly IReadOnlyDictionary<(Point topLeft, Point bottomRight), int> controlLocations;
        private readonly IMouseInput input;

        public MouseInputControl(VisualizationSettings settings, IMouseInput input)
        {
            this.input = input;
            controlLocations = settings.ControlTools;
        }

        public void Subscribe(Controller controller)
        {
            input.Click += controller.MakeStep;
        }

        public int? MakeInput(EventArgs e)
        {
            var ev = (MouseEventArgs) e;
            if (ev.Button == MouseButtons.Right)
                return null;
            var location = ev.Location;
            foreach (var coords in controlLocations)
            {
                var clickX = location.X;
                var clickY = location.Y;
                var (topLeft, bottomRight) = coords.Key;
                if (topLeft.X >= clickX || clickX >= bottomRight.X || topLeft.Y >= clickY || clickY >= bottomRight.Y)
                    continue;
                return coords.Value;
            }

            return null;
        }
    }
}