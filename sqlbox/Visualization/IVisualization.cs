using System.Collections.Generic;

namespace sqlbox.Visualization
{
    public interface IVisualization
    {
        string Name { get; }

        string GetHtml(List<List<object>> data);
    }
}