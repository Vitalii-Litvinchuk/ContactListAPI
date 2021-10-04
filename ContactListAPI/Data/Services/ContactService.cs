using ContactListAPI.Data.Models;
using ContactListAPI.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactListAPI.Data.Services
{
    public class ContactService
    {
        private readonly ContactListDbContext _db;

        public ContactService(ContactListDbContext db)
        {
            _db = db;
        }

        #region Adds

        public Contact AddContact(ContactVM contactVM)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Name = contactVM.Name,
                Phone = contactVM.Phone,
                Email = contactVM.Email,
                Gender = contactVM.Gender,
                Image = contactVM.Image,
                Status = contactVM.Status
            };
            _db.Contacts.Add(contact);
            _db.SaveChanges();
            return contact;
        }

        #endregion

        #region Gets

        public List<Contact> GetAllContacts()
        {
            var allContacs = _db.Contacts.ToList();
            return allContacs;
        }

        #endregion

        #region Deletes

        public void DeleteContact(string id)
        {
            _db.Contacts.Remove(_db.Contacts.FirstOrDefault(c => c.Id.ToString() == id));
            _db.SaveChanges();
        }

        #endregion

        #region Edits
        public Contact UpdateContact(Contact contact)
        {
            _db.Contacts.Update(contact);
            _db.SaveChanges();
            return contact;
        }

        #endregion
    }
}
