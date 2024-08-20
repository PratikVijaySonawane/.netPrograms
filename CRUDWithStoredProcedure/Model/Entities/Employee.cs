namespace CRUDWithStoredProcedure.Model.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public int Active { get; set; }
    }
}
