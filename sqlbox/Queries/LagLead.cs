using sqlbox.Queries.Parameters;

namespace sqlbox.Queries
{
    public class LagLead : QueryBase
    {
        public LagLead()
        {
            Name = "LAG a LEAD";
            Description = "Použití window funkce LAG a LEAD.";
            IsDemo = true;
            Tutorial = "~/Tutorial/LagLead.cshtml";
            Parameters.Add(new LagLeadParameter());
            ParameterForm = "LagLead";
            Query = "SELECT jmeno, plat, [LagLead](plat) OVER (ORDER BY plat) AS lags FROM zamestnanci";
        }
    }
}