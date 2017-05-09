namespace sqlbox.Queries
{
    public class Report11 : QueryBase
    {
        public Report11()
        {
            Name = "Data změn verze";
            Description = "Výsledek je materializován, výsledek je omezen na 200 položek";
            Query = "SELECT * FROM view_version_change LIMIT 200";
            DisplayQuery = "SELECT current_version, next_version, \"time\"::date AS changed\r\n" +
                           "\tFROM (\r\n" +
                           "\t\tSELECT program_ver AS current_version, lead(program_ver) OVER (PARTITION BY pda_imei, car_key ORDER BY \"time\") AS next_version, \"time\"\r\n" +
                           "\t\t\tFROM pair_log\r\n" +
                           "\t) AS q\r\n" +
                           "\tWHERE current_version != next_version";
        }
    }
}