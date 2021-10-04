using ContactListAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactListAPI.Data
{

    public class ContactListDbContext : DbContext
    {
        public ContactListDbContext(DbContextOptions<ContactListDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
