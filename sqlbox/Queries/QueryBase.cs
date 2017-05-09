using System.Collections.Generic;
using sqlbox.Interpreter;

namespace sqlbox.Queries
{
    public abstract class QueryBase : IQuery
    {
        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public bool IsDemo { get; protected set; }

        public string Query { get; protected set; }

        public string Tutorial { get; protected set; }

        public List<Visualization> Visualizations { get; } = new List<Visualization>();
    }
}