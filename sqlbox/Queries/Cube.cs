namespace sqlbox.Queries
{
    public class Cube : QueryBase
    {
        public Cube()
        {
            Name = "CUBE";
            Description = "Použití kostky pro agregaci údajů.";
            IsDemo = true;
            Tutorial = "~/Tutorial/Cube.cshtml";
            Query = "SELECT oddeleni, pohlavi, SUM(plat) AS totalsalary\r\n\tFROM zamestnanci\r\n\tGROUP BY CUBE(oddeleni, pohlavi)";
        }
    }
}