namespace CRUDWithStoredProcedure.Model
{
    public class UpdateEmployee
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public int Active { get; set; }
    }
}
