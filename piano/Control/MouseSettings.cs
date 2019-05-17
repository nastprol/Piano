using Piano.Control;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano
{
    public class MouseSettings : ISettings<Tuple<Point, Point>>
    {
        private Dictionary<Tuple<Point, Point>, int> conntrolLocations = new Dictionary<Tuple<Point, Point>, int> {
            { new Tuple<Point, Point>(new Point(0, 300), new Point(50, 400)), 0 },
            { new Tuple<Point, Point>(new Point(50, 300), new Point(100, 400)), 1 },
            { new Tuple<Point, Point>(new Point(100, 300), new Point(150, 400)), 2 },
            { new Tuple<Point, Point>(new Point(150, 300), new Point(200, 400)), 3 }
        };

        public IReadOnlyDictionary<Tuple<Point, Point>, int> ControlTools => conntrolLocations;
    }
}
