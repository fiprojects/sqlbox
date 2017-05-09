namespace sqlbox.Queries
{
    public class Report8 : QueryBase
    {
        public Report8()
        {
            Name = "Délka používání zařízení";
            Description = "Suma pda_run_time. Výsledek je materializován.";
            Query = "SELECT * FROM view_imei_run_time";
            DisplayQuery = "SELECT pda_imei, sum(pda_run_time)\r\n" +
                           "\tFROM (\r\n" +
                           "\t\tSELECT pda_imei, \"time\", pda_run_time, lead(pda_run_time) OVER (PARTITION BY pda_imei, car_key ORDER BY \"time\") AS next_time\r\n" +
                           "\t\t\tFROM pair_log\r\n" +
                           "\t) AS q\r\n" +
                           "\tWHERE pda_run_time > next_time OR next_time IS NULL\r\n" +
                           "\tGROUP BY pda_imei";
        }
    }
}