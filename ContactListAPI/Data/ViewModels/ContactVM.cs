using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactListAPI.Data.ViewModels
{
    public class ContactVM
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Status { get; set; }

        public string Gender { get; set; }

        public string Image { get; set; }
    }
}
