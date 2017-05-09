namespace sqlbox.Queries
{
    public class Report2 : QueryBase
    {
        public Report2()
        {
            Name = "Počet různých device pro každou verzi programu";
            Description = "Výsledek je materializován";
            Query = "SELECT * FROM view_version_device";
            DisplayQuery = "SELECT program_ver, count(DISTINCT device)\r\n" +
                               "\t\tFROM pair_log\r\n" +
                               "\t\tGROUP BY program_ver";
        }
    }
}