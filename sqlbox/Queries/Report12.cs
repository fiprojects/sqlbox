namespace sqlbox.Queries
{
    public class Report12 : QueryBase
    {
        public Report12()
        {
            Name = "Doba strávená vozem v určité GSM síti";
            Description = "Výsledek je materializován, výsledek je omezen na 200 položek";
            Query = "SELECT * FROM view_gsm_usage LIMIT 200";
            DisplayQuery = "SELECT car_key, gsmnet_id, sum(net_time) \r\n" +
                           "\tFROM (\r\n" +
                           "\t\tSELECT car_key, gsmnet_id, lead(\"time\") OVER (PARTITION BY car_key ORDER BY \"time\") - \"time\" AS net_time\r\n" +
                           "\t\t\tFROM (\r\n" +
                           "\t\t\t\tSELECT car_key, current_net AS gsmnet_id, \"time\"\r\n" +
                           "\t\t\t\t\tFROM (\r\n" +
                           "\t\t\t\t\t\tSELECT car_key, gsmnet_id AS current_net, lag(gsmnet_id) OVER (PARTITION BY car_key ORDER BY \"time\") AS prev_net, \"time\"\r\n" +
                           "\t\t\t\t\t\t\tFROM pair_log\r\n" +
                           "\t\t\t\t\t) AS q1\r\n" +
                           "\t\t\t\t\tWHERE current_net != prev_net OR prev_net IS NULL\r\n" +
                           "\t\t\t) AS q2\r\n" +
                           "\t) AS q3\r\n" +
                           "\tGROUP BY car_key, gsmnet_id";
        }
    }
}