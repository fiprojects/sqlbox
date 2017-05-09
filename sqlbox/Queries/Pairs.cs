namespace sqlbox.Queries
{
    public class Pairs : QueryBase
    {
        public Pairs()
        {
            Name = "Spárované události";
            Description = "Ukázková data vzniklá párováním tabulky conn_log a service_log pomocí metody 2 (materializovaný pohled, omezeno na 200 položek)";
            Query = "SELECT * FROM pair_log LIMIT 200";
            DisplayQuery =
                "SELECT\r\n" +
                        "\t\ts2.service_key, s2.car_key, s2.\"time\", s2.app_run_time, s2.pda_run_time, s2.device,\r\n" +
                        "\t\tc2.log_key, c2.\"time\" AS log_time, c2.gsmnet_id, c2.pda_imei, c2.sim_imsi, c2.program_ver\r\n" +
                    "\tFROM (\r\n" +
                        "\t\tSELECT\r\n" +
                            "\t\t\ts1.service_key, s1.car_key, s1.\"time\", s1.app_run_time, s1.pda_run_time, s1.device,\r\n" +
                            "\t\t\t(\r\n" +
                                "\t\t\t\tSELECT c1.log_key\r\n" +
                                    "\t\t\t\t\tFROM conn_log c1\r\n" +
                                    "\t\t\t\t\tWHERE c1.car_key = s1.car_key AND c1.\"time\" <= s1.\"time\"\r\n" +
                                    "\t\t\t\t\tORDER BY c1.\"time\" DESC\r\n" +
                                    "\t\t\t\t\tDESC LIMIT 1\r\n" +
                            "\t\t\t) AS log_key\r\n" +
                        "\t\tFROM service_log s1\r\n" +
                    "\t) s2\r\n" +
                    "\tJOIN conn_log c2 ON c2.log_key = s2.log_key";
        }
    }
}