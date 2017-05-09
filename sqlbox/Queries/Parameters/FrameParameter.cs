using sqlbox.Interpreter;

namespace sqlbox.Queries.Parameters
{
    public class FrameParameter : Parameter
    {
        public FrameParameter()
        {
            Name = "Frame";
            Choices.Add("PreceedingRange", "RANGE UNBOUNDED PRECEDING");
            Choices.Add("Preceeding", "ROWS UNBOUNDED PRECEDING");
            Choices.Add("Following", "ROWS BETWEEN CURRENT ROW AND UNBOUNDED FOLLOWING");
            Choices.Add("Between", "ROWS BETWEEN 1 PRECEDING AND 1 FOLLOWING");
        }
    }
}