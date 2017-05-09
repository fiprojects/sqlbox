using System;
using System.Collections.Generic;
using System.Diagnostics;
using Npgsql;
using sqlbox.Config;
using sqlbox.Queries;

namespace sqlbox.Interpreter
{
    public class QueryExecutor
    {
        private readonly ConnectionStrings _connectionStrings;
        private readonly IQuery _query;

        public int RowCount { get; private set; }

        public long ExecutionTime { get; private set; }

        public List<string> ColumnNames { get; } = new List<string>();

        public List<List<object>> Result { get; } = new List<List<object>>();

        public QueryExecutor(ConnectionStrings connectionStrings, IQuery query)
        {
            _connectionStrings = connectionStrings;
            _query = query;
        }

        public void Run()
        {
            var connectionString = _query.IsDemo ? _connectionStrings.Korporace : _connectionStrings.Report;

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(_query.Query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            ColumnNames.Add(reader.GetName(i));
                        }

                        while (reader.Read())
                        {
                            var row = new List<object>();
                            for (var i = 0; i < reader.FieldCount; i++)
                            {
                                if (reader.GetValue(i) == DBNull.Value)
                                {
                                    return;
                                }

                                row.Add(reader.GetValue(i));
                            }
                            Result.Add(row);

                            RowCount++;
                        }
                    }
                }
            }
            stopwatch.Stop();

            ExecutionTime = stopwatch.ElapsedMilliseconds;
        }
    }
}