using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Entities.Dtos
{
    public class PropertyUpdateDto
    {
        public int IdProperty { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Area { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int Year { get; set; }
        public IFormFile MainImage { get; set; }
        public string CodeInternal { get; set; }
    }
}
