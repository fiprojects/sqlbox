using sqlbox.Interpreter;

namespace sqlbox.Queries.Parameters
{
    public class LagLeadParameter : Parameter
    {
        public LagLeadParameter()
        {
            Name = "LagLead";
            Choices.Add("Lag", "LAG");
            Choices.Add("Lead", "LEAD");
        }
    }
}