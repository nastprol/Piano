using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Domain
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

        public event EventHandler<InputEventArgs> Input;

        public void MakeInput(object sender, EventArgs ev)
        {
            var e = (MouseEventArgs)ev;
            if (e.Button != MouseButtons.Right)
            {
                var location = e.Location;
                foreach (var coords in controlLocations)
                {
                    var clickX = location.X;
                    var clickY = location.Y;
                    var (topLeft, bottomRight) = coords.Key;
                    if (topLeft.X <= clickX && clickX <= bottomRight.X && topLeft.Y <= clickY && clickY <= bottomRight.Y)
                    {
                        Input.Invoke(this, new InputEventArgs(coords.Value));
                        break;
                    }
                }
            }
        }

        public void Subscribe()
        {
            input.Click += MakeInput;
        }

        public void Unsubscribe()
        {
            input.Click -= MakeInput;
        }
    }
}