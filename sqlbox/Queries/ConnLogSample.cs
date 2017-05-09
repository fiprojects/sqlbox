namespace sqlbox.Queries
{
    public class ConnLogSample : QueryBase
    {
        public ConnLogSample()
        {
            Name = "Ukázka tabulky conn_log";
            Description = "Ukázková data z tabulky conn_log (omezeno na 200 položek).";
            Query = "SELECT * FROM conn_log LIMIT 200";
            DisplayQuery = "SELECT * FROM conn_log";
        }
    }
}