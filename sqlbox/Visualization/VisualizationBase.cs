using System.Collections.Generic;

namespace sqlbox.Visualization
{
    public abstract class VisualizationBase : IVisualization
    {
        public string Name { get; protected set; }

        public abstract string GetHtml(List<List<object>> data);
    }
}