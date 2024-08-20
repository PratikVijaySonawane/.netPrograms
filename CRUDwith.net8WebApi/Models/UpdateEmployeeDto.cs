namespace CRUDwith.net8WebApi.Models
{
    /* Here we have added the dto class to accept the data without Guid id*/
    public class UpdateEmployeeDto
    {
        /* Adding the setter and getter Fields, So We can set and get the Fields */
        public required string Name { get; set; }

        public required string Email { get; set; }

        public string? Phone { get; set; }

        public decimal Salary { get; set; }

    }
}
