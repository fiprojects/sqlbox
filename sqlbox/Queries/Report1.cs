namespace sqlbox.Queries
{
    public class Report1 : QueryBase
    {
        public Report1()
        {
            Name = "Počet různých pda_imei pro každou verzi programu";
            Description = "Výsledek je materializován";
            Query = "SELECT * FROM view_version_imei";
            DisplayQuery = "SELECT program_ver, count(DISTINCT pda_imei)\r\n" +
                               "\t\tFROM pair_log\r\n" +
                               "\t\tGROUP BY program_ver";
        }
    }
}