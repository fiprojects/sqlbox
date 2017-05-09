using System.Collections.Generic;
using sqlbox.Config;
using sqlbox.Interpreter;
using sqlbox.Queries;

namespace sqlbox.ViewModels
{
    public class StandardQueryViewModel
    {
        private readonly IQuery _query;

        private readonly QueryExecutor _queryExecutor;

        public string Title => _query.Name;

        public string Description => _query.Description;

        public List<Visualization> Visualizations => _query.Visualizations;

        public string Tutorial => _query.Tutorial;

        public string Query => _query.Query;

        public int ColumnCount => _queryExecutor.ColumnNames.Count;

        public int RowCount => _queryExecutor.RowCount;

        public double ExecutionTime => _queryExecutor.ExecutionTime;

        public List<string> ColumnNames => _queryExecutor.ColumnNames;

        public List<List<object>> Result => _queryExecutor.Result;

        public StandardQueryViewModel(ConnectionStrings connectionStrings, IQuery query)
        {
            _query = query;

            _queryExecutor = new QueryExecutor(connectionStrings, _query);
            _queryExecutor.Run();
        }
    }
}