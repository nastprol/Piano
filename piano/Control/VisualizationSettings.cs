using System.Collections.Generic;
using System.Drawing;

namespace Piano
{
    public class VisualizationSettings
    {
        private readonly Dictionary<(Point topLeft, Point bottomRight), int> controlLocations =
            new Dictionary<(Point topLeft, Point bottomRight), int>
            {
                {(new Point(0, 300), new Point(50, 400)), 0},
                {(new Point(50, 300), new Point(100, 400)), 1},
                {(new Point(100, 300), new Point(150, 400)), 2},
                {(new Point(150, 300), new Point(200, 400)), 3}
            };

        public IReadOnlyDictionary<(Point topLeft, Point bottomRight), int> ControlTools => controlLocations;
    }
}