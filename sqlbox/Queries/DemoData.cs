namespace sqlbox.Queries
{
    public class DemoData : QueryBase
    {
        public DemoData()
        {
            Name = "Ukázková data";
            Description = "Ukázková data použitá pro názornou demonstraci analytických dotazů.";
            IsDemo = true;
            Query = "SELECT * FROM zamestnanci";
        }
    }
}