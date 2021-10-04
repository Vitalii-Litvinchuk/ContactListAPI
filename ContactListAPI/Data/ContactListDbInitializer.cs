using ContactListAPI.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactListAPI.Data
{
    public static class ContactListDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ContactListDbContext>();
                if (!context.Contacts.Any())
                {
                    context.AddRange(new Contact()
                    {
                        Email =
                        "example@example.example",
                        Gender =
                        "men",
                        Image =
                        "13",
                        Name =
                        "Hello world",
                        Phone =
                        "+1-800-600-9898",
                        Status =
                        "Friend",
                    }, new Contact()
                    {
                        Email =
                        "example@example.example",
                        Gender =
                        "women",
                        Image =
                        "0",
                        Name =
                        "Someone",
                        Phone =
                        "+1-800-600-9898",
                        Status =
                        "Family"

                    }, new Contact()
                    {
                        Email =
                        "example@example.example",
                        Gender =
                        "men",
                        Image =
                        "30",
                        Name =
                        "asda",
                        Phone =
                        "+1-800-600-9898",
                        Status =
                        "Work"

                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
