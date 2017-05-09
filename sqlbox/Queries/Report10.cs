using sqlbox.Visualization;

namespace sqlbox.Queries
{
    public class Report10 : QueryBase
    {
        public Report10()
        {
            Name = "Četnost restartu zařízení (device)";
            Description = "Výsledek je materializován";
            Query = "SELECT * FROM view_device_restarts";
            DisplayQuery = "SELECT pda_imei, count(*) AS restarts\r\n" +
                           "\tFROM (\r\n" +
                           "\t\tSELECT pda_imei, pda_run_time, lag(pda_run_time) OVER (PARTITION BY pda_imei, car_key ORDER BY \"time\") AS prev_time\r\n" +
                           "\t\t\tFROM pair_log\r\n" +
                           "\t) AS q\r\n" +
                           "\tWHERE pda_run_time < prev_time\r\n" +
                           "\tGROUP BY pda_imei";
            Visualizations.Add(new ColumnChart("Četnost restartu zařízení"));
        }
    }
}