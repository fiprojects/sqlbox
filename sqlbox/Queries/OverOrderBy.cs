namespace sqlbox.Queries
{
    public class OverOrderBy : QueryBase
    {
        public OverOrderBy()
        {
            Name = "OVER ORDER BY";
            Description = "Použití window funkce OVER s ORDER BY.";
            IsDemo = true;
            Tutorial = "~/Tutorial/OverOrderBy.cshtml";
            Query = "SELECT jmeno, plat, SUM(plat) OVER (ORDER BY plat) AS sumo\r\nFROM zamestnanci";
        }
    }
}