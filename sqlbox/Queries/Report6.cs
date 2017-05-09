namespace sqlbox.Queries
{
    public class Report6 : QueryBase
    {
        public Report6()
        {
            Name = "Počet restartů programu pro každé zařízení (device)";
            Description = "Výsledek je materializován";
            Query = "SELECT * FROM view_device_app_restarts";
            DisplayQuery = "SELECT pda_imei, count(*) AS restarts\r\n" +
                           "\tFROM (\r\n" +
                           "\t\tSELECT pda_imei, app_run_time, lag(app_run_time) OVER (PARTITION BY pda_imei, car_key ORDER BY \"time\") AS prev_time\r\n" +
                           "\t\t\tFROM pair_log\r\n" +
                           "\t) AS q\r\n" +
                           "\tWHERE app_run_time < prev_time\r\n" +
                           "\tGROUP BY pda_imei";
        }
    }
}