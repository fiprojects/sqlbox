namespace sqlbox.Queries
{
    public class SumWithoutOver : QueryBase
    {
        public SumWithoutOver()
        {
            Name = "SUM bez OVER";
            Description = "SUM bez použití GROUP BY.";
            IsDemo = true;
            Query = "SELECT SUM(plat) FROM zamestnanci";
        }
    }
}