namespace CRUDInMVCFromScratch.Models
{
    public class Employees
    {
        /* Declaring the Fields */
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public string Salary { get; set; }
    }
}
