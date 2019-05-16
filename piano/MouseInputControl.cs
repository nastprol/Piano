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
        private Dictionary<Tuple<Point, Point>, int> conntrolLocations;
        public int InputValue { get; private set; }


        public MouseInputControl(Dictionary<Tuple<Point, Point>, int> conntrolLocations)
        {
            this.conntrolLocations = conntrolLocations;

        }

        public void Subscribe(Form form, Сontroller сontroller)
        {
            form.Click += сontroller.MakeStep;
        }

        public bool MakeInput(EventArgs e)
        {
            var location = ((MouseEventArgs)e).Location;
            foreach (var coords in conntrolLocations.Keys)
            {
                var x = location.X;
                var y = location.Y;
                var coord1 = coords.Item1;
                var coord2 = coords.Item2;
                if (coord1.X < x && x < coord2.X && coord1.Y < y && y < coord2.Y)
                {
                    InputValue = conntrolLocations[coords];
                    return true;
                }
            }
            return false;
        }
    }
}
