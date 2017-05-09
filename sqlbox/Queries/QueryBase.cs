using System.Collections.Generic;
using sqlbox.Interpreter;

namespace sqlbox.Queries
{
    public abstract class QueryBase : IQuery
    {
        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public bool IsDemo { get; protected set; }

        public string Query { get; set; }

        public string DisplayQuery { get; set; }

        public string Tutorial { get; protected set; }

        public string ParameterForm { get; protected set; }

        public List<Parameter> Parameters { get; } = new List<Parameter>();

        public List<Visualization> Visualizations { get; } = new List<Visualization>();
    }
}