namespace sqlbox.Queries
{
    public class OlapCube : QueryBase
    {
        public OlapCube()
        {
            Name = "OLAP kostka";
            Description = "Kostka vytvořená z OLAP dat. Rozměry kostky: pda_imei, program_ver, měsíc vypočítaný z time. Sledujeme počet restartů. Materializovaný pohled, omezeno na 500 položek";
            Query = "SELECT * FROM view_olap LIMIT 500";
            DisplayQuery = "SELECT pda_imei, program_ver, month, sum(restarts) AS sum\r\n" +
                           "\tFROM view_olap_data \r\n" +
                           "\tGROUP BY CUBE(pda_imei, program_ver, month)";
        }
    }
}