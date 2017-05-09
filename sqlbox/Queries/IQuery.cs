using System.Collections.Generic;
using sqlbox.Interpreter;

namespace sqlbox.Queries
{
    public interface IQuery
    {
        string Name { get; }

        string Description { get; }

        bool IsDemo { get; }

        string Query { get; set; }

        string DisplayQuery { get; set; }

        string Tutorial { get; }

        string ParameterForm { get; }

        List<Parameter> Parameters { get; }

        List<Visualization> Visualizations { get; }
    }
}