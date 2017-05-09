namespace sqlbox.Queries
{
    public class Report7 : QueryBase
    {
        public Report7()
        {
            Name = "Čas uvedení zařízení (pda_imei) do provozu";
            Description = "Výsledek je materializován, výsledek omezen na 200 položek";
            Query = "SELECT * FROM view_imei_start_time LIMIT 200";
            DisplayQuery = "SELECT pda_imei, \"time\" - pda_run_time * interval '1 hour' AS start_time\r\n" +
                "\tFROM (\r\n" +
                "\t\tSELECT pda_imei, \"time\", pda_run_time, lag(pda_run_time) OVER (PARTITION BY pda_imei, car_key ORDER BY \"time\") AS prev_time\r\n" +
                "\t\t\tFROM pair_log\r\n" +
                "\t) AS q\r\n" +
                "\tWHERE pda_run_time < prev_time OR prev_time IS NULL";
        }
    }
}