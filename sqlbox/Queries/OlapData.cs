namespace sqlbox.Queries
{
    public class OlapData : QueryBase
    {
        public OlapData()
        {
            Name = "OLAP data";
            Description = "Zdroj dat pro OLAP kostku, materializovaný pohled, omezeno na 500 položek";
            Query = "SELECT * FROM view_olap_data LIMIT 500";
            DisplayQuery = "SELECT pda_imei, program_ver, month, count(*) AS restarts\r\n" +
                           "\tFROM (\r\n" +
                           "\t\tSELECT pda_imei, program_ver, month, app_run_time, lag(app_run_time) OVER (PARTITION BY pda_imei, program_ver, month ORDER BY \"time\") AS prev_time\r\n" +
                           "\t\t\tFROM (\r\n" +
                           "\t\t\t\tSELECT pda_imei, program_ver, \"time\", date_part('month', \"time\") AS month, app_run_time\r\n" +
                           "\t\t\t\t\tFROM pair_log\r\n" +
                           "\t\t\t) AS q1\r\n" +
                           "\t) AS q2\r\n" +
                           "\tWHERE app_run_time < prev_time\r\n" +
                           "\tGROUP BY pda_imei, program_ver, month";
        }
    }
}