using System.Collections.Generic;

namespace sqlbox.Interpreter
{
    public abstract class Parameter : IParameter
    {
        public string Name { get; protected set; }

        public Dictionary<string, string> Choices { get; } = new Dictionary<string, string>();
    }
}