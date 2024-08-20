using ContectsCrudWebApi.Data;
using ContectsCrudWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContectsCrudWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        /* Declaring te private variable*/
        private readonly ContactApiDbContacts dbContext;

        /*Creating the constructor */
        public ContactsController(ContactApiDbContacts dbContext)
        {
            this.dbContext= dbContext;
        }

        /* Declaring the Method to Get all contacts */
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await dbContext.contacts.ToListAsync());
            
        }


        /* Declaring the Method to get the single contact */
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContact([FromRoute] Guid id)
        {
            var contact = await dbContext.contacts.FindAsync(id);
            if(contact == null)
            {
                return NotFound();
            }
            
            return Ok(contact);
        }

        /* Declaring the Method to add the Contacts into the database */
        [HttpPost]
        public async Task<IActionResult> AddContacts(AddContactRequets addContactRequest)
        {
            var Contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Address = addContactRequest.Address,
                Email = addContactRequest.Email,
                FullName = addContactRequest.FullName,
                Phone = addContactRequest.Phone,
            };
            await dbContext.contacts.AddAsync(Contact);
            await dbContext.SaveChangesAsync();

            return Ok(Contact);
        }

        /* Declaring the Method to Update the Contact */
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContacts([FromRoute] Guid id,UpdateContactRequest updateContactRequest)
        {
            var contact = await dbContext.contacts.FindAsync(id);

            if(contact != null)
            {
                contact.FullName = updateContactRequest.FullName;
                contact.Address = updateContactRequest.Address;
                contact.Phone = updateContactRequest.Phone;
                contact.Email = updateContactRequest.Email;

                await dbContext.SaveChangesAsync();
                return Ok(contact);
            }

            return NotFound();
        }

        /* Declaring the Method to delete the contact */
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var contact = await dbContext.contacts.FindAsync(id);

            if(contact != null)
            {
                dbContext.contacts.Remove(contact);
                await dbContext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        } 
    }
}
