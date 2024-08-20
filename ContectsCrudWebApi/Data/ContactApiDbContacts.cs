using ContectsCrudWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContectsCrudWebApi.Data
{
    public class ContactApiDbContacts : DbContext
    {
        public ContactApiDbContacts(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> contacts { get; set; }
    }
}
