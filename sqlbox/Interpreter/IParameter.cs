using System.Collections.Generic;

namespace sqlbox.Interpreter
{
    public interface IParameter
    {
        string Name { get; }

        Dictionary<string, string> Choices { get; }
    }
}