using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Entities.Dtos
{
    public class PropertyImageUpdateDto
    {
        public int IdPropertyImage { get; set; }
        public int IdProperty { get; set; }
        public IFormFile Image { get; set; }
        public bool Enabled { get; set; }
    }
}
