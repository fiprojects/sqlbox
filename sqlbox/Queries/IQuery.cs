using System.Collections.Generic;
using sqlbox.Interpreter;

namespace sqlbox.Queries
{
    public interface IQuery
    {
        string Name { get; }

        string Description { get; }

        bool IsDemo { get; }

        string Query { get; }

        string Tutorial { get; }

        List<Visualization> Visualizations { get; }
    }
}