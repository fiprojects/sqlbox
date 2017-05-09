namespace sqlbox.Queries
{
    public class Statistics : QueryBase
    {
        public Statistics()
        {
            Name = "Statistika";
            Description = "Základní statistika z tabulek conn_log a service_log.";
            Query = "SELECT * FROM statistics ORDER BY key";
        }
    }
}