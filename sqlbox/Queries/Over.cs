namespace sqlbox.Queries
{
    public class Over : QueryBase
    {
        public Over()
        {
            Name = "OVER";
            Description = "Použití window funkce OVER.";
            IsDemo = true;
            Query = "SELECT jmeno, plat, SUM(plat) OVER () AS sumo FROM zamestnanci";
        }
    }
}