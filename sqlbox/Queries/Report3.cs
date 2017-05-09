namespace sqlbox.Queries
{
    public class Report3 : QueryBase
    {
        public Report3()
        {
            Name = "Počet restartů programu pro každou verzi";
            Description = "Za restart se považuje náhlý pokles app_run_time. Výsledek je materializován.";
            Query = "SELECT * FROM view_version_restarts";
            DisplayQuery = "SELECT program_ver, count(*) AS restarts\r\n" +
                           "\tFROM (\r\n" +
                           "\t\tSELECT program_ver, car_key, app_run_time, lag(app_run_time) OVER (PARTITION BY program_ver, car_key ORDER BY \"time\") AS prev_time\r\n" +
                           "\t\t\tFROM pair_log\r\n" +
                           "\t) AS q\r\n" +
                           "\tWHERE app_run_time < prev_time\r\n" +
                           "\tGROUP BY program_ver";
        }
    }
}