namespace sqlbox.Queries
{
    public class OverPartitionBy : QueryBase
    {
        public OverPartitionBy()
        {
            Name = "OVER PARTITION BY";
            Description = "Použití window funkce OVER s PARITION BY.";
            IsDemo = true;
            Tutorial = "~/Tutorial/OverPartitionBy.cshtml";
            Query = "SELECT jmeno, oddeleni, SUM(plat) OVER (PARTITION BY oddeleni) AS sumo FROM zamestnanci";
        }
    }
}