namespace sqlbox.Queries
{
    public class OverPartitionByOrderBy : QueryBase
    {
        public OverPartitionByOrderBy()
        {
            Name = "OVER PARTITION BY, ORDER BY";
            Description = "Použití window funkce OVER s PARITION BY a ORDER BY.";
            IsDemo = true;
            Tutorial = "~/Tutorial/OverPartitionByOrderBy.cshtml";
            Query = "SELECT plat, oddeleni, rank() OVER (PARTITION BY oddeleni ORDER BY plat DESC)\r\nFROM zamestnanci";
        }
    }
}