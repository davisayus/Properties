using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Entities.Entities
{
    public class Owner
    {
        [Key]
        public int IdOwner { get; set; }
        public int IdNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }

        public virtual IEnumerable<Property> Property { get; set; }
    }
}
