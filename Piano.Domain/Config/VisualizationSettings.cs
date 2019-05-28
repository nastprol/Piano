using System.Collections.Generic;
using System.Drawing;

namespace Domain
{
    public class VisualizationSettings
    {
        private readonly Dictionary<(Point topLeft, Point bottomRight), int> controlLocations;
           

        public VisualizationSettings(KeySettings keySettings)
        {
            var coordinates = new Dictionary<(Point topLeft, Point bottomRight), int>();
            var width = keySettings.Width; 
            var height = keySettings.Height; 
            for (var i = 0; i < 4; i++) 
            {
                coordinates.Add((new Point(i * width, 300), new Point((i + 1) * width, 300 + height)), i);
            }
            controlLocations = coordinates;
        }

        public IReadOnlyDictionary<(Point topLeft, Point bottomRight), int> ControlTools => controlLocations;
    }
}