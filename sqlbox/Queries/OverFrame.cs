using sqlbox.Queries.Parameters;

namespace sqlbox.Queries
{
    public class OverFrame : QueryBase
    {
        public OverFrame()
        {
            Name = "OVER s FRAME klauzulí";
            Description = "Použití window funkce OVER s FRAME klauzulí.";
            IsDemo = true;
            Parameters.Add(new FrameParameter());
            ParameterForm = "OverFrame";
            Query = "SELECT jmeno, plat, SUM(plat) OVER (ORDER BY plat [Frame]) AS sumo FROM zamestnanci";
        }
    }
}