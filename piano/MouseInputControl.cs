using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Piano
{
    public class MouseInputControl : IInputControl
    {
        private Dictionary<Point, int> conntrolLocations;
        public int InputValue { get; private set; }

        public MouseInputControl(Dictionary<Point, int> conntrolLocations)
        {
            this.conntrolLocations = conntrolLocations;
        }

        public void ClickMouse(object sender, EventArgs e)
        {
            var location = ((MouseEventArgs)e).Location;
            if (conntrolLocations.ContainsKey(location))
                InputValue = conntrolLocations[location];
        }
    }
}
