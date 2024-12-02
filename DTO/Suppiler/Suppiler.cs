using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Suppiler
{
    public class Suppiler
    {
        public string Name { get; set; }
        public string Phone { get; set; }

        public string Email { get; set; }

        public string Adress { get; set; }

        public Suppiler(string name, string phone, string email, string adress)
        {
            Name = name;
            Phone = phone;
            Email = email;
            Adress = adress;
        }
    }
}
