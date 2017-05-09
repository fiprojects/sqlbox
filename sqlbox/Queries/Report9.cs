namespace sqlbox.Queries
{
    public class Report9 : QueryBase
    {
        public Report9()
        {
            Name = "Četnost restartu zařízení (pda_imei)";
            Description = "Výsledek je materializován";
            Query = "SELECT * FROM view_imei_restarts";
            DisplayQuery = "SELECT device, count(*) AS restarts\r\n" +
                           "\tFROM (\r\n" +
                           "\t\tSELECT device, pda_run_time, lag(pda_run_time) OVER (PARTITION BY device, car_key ORDER BY \"time\") AS prev_time\r\n" +
                           "\t\t\tFROM pair_log\r\n" +
                           "\t) AS q\r\n" +
                           "\tWHERE pda_run_time < prev_time\r\n" +
                           "\tGROUP BY device";
        }
    }
}