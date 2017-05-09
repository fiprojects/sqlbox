namespace sqlbox.Queries
{
    public class ServiceLogSample : QueryBase
    {
        public ServiceLogSample()
        {
            Name = "Ukázka tabulky service_log";
            Description = "Ukázková data z tabulky service_log (omezeno na náhodných 200 položek).";
            Query = "SELECT * FROM service_log LIMIT 200";
            DisplayQuery = "SELECT * FROM service_log";
        }
    }
}