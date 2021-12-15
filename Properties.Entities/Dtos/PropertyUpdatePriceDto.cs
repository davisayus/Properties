using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Entities.Dtos
{
    public class PropertyUpdatePriceDto
    {
        public int IdProperty { get; set; }
        public int NewPrice { get; set; }

    }
}
