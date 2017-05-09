namespace sqlbox.Queries
{
    public class Rollup : QueryBase
    {
        public Rollup()
        {
            Name = "ROLLUP";
            Description = "Použití ROLLUP pro agregaci údajů.";
            IsDemo = true;
            Tutorial = "~/Tutorial/Rollup.cshtml";
            Query = "SELECT oddeleni, SUM(plat) AS sumo\r\n\tFROM zamestnanci\r\n\tGROUP BY ROLLUP(oddeleni)";
        }
    }
}