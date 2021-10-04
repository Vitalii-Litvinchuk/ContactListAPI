using ContactListAPI.Data.Models;
using ContactListAPI.Data.Services;
using ContactListAPI.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactListAPI.Controllers
{
    public class ContactsController : Controller
    {
        public ContactService _contactService;

        public ContactsController(ContactService contactService)
        {
            _contactService = contactService;
        }

        #region Posts
        [HttpPost("add-new-contact")]
        public IActionResult AddNewContact([FromBody] ContactVM contactVM)
        {
            var  contact = _contactService.AddContact(contactVM);
            return Ok(contact);
        }


        #endregion

        #region Gets
        [HttpGet("get-all-contacts")]
        public IActionResult GetAllContacts()
        {
            var contacts = _contactService.GetAllContacts();
            return Ok(contacts);
        }

        #endregion

        #region Deletes
        [HttpDelete("delete-contact")]
        public IActionResult DeleteContact([FromBody] string Id)
        {
            _contactService.DeleteContact(Id);
            return Ok();
        }

        #endregion

        #region Edits
        [HttpPut("update-contact")]
        public IActionResult UpdateContact([FromBody] Contact contact)
        {
            var con = _contactService.UpdateContact(contact);
            return Ok(con);
        }

        #endregion
    }
}
