using sqlbox.Visualization;

namespace sqlbox.Queries
{
    public class Report4 : QueryBase
    {
        public Report4()
        {
            Name = "Počet pádů programu pro každou verzi";
            Description = "Za pád aplikace se považuje restart s rychlou dobou znovuspuštění (do jedné minuty). Výsledek je materializován.";
            Query = "SELECT * FROM view_version_crashes";
            DisplayQuery = "SELECT program_ver, count(*) AS restarts\r\n" +
                "\tFROM(\r\n" +
                "\t\tSELECT\r\n" +
                "\t\t\t\tprogram_ver,\r\n" +
                "\t\t\t\tcar_key,\r\n" +
                "\t\t\t\tapp_run_time,\r\n" +
                "\t\t\t\tlag(app_run_time) OVER(PARTITION BY program_ver, car_key ORDER BY \"time\") AS prev_time,\r\n" +
                "\t\t\t\t\"time\" - lag(\"time\") OVER(PARTITION BY program_ver, car_key ORDER BY \"time\") AS prev_time\r\n" +
                "\t\t\tFROM pair_log\r\n" +
                "\t) AS q\r\n" +
                "\tWHERE app_run_time < prev_time AND time_diff <= interval '1 minute'\r\n" +
                "\tGROUP BY program_ver";
            Visualizations.Add(new ColumnChart("Počet pádů programu"));
        }
    }
}