using System;
using System.Reflection;
using sqlbox.Queries;

namespace sqlbox.Interpreter
{
    public class QuerySelector
    {
        public static IQuery GetInstance(string name)
        {
            name = "sqlbox.Queries." + name;
            var type = Type.GetType(name);
            if (type == null || !typeof(IQuery).IsAssignableFrom(type))
            {
                return null;
            }

            return Activator.CreateInstance(type) as IQuery;
        }
    }
}