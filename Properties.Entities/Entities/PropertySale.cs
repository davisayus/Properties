using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Entities.Entities
{
    public class PropertySale
    {
        public int IdPropertySale { get; set; }
        public DateTime DateSale { get; set; }
        public string BuyerName { get; set; }
        public Decimal Value { get; set; }
        public Decimal Tax { get; set; }
        public int IdProperty { get; set; }
        public string UserProcess { get; set; }
        public DateTime DateTimeProcess { get; set; }
        public virtual Property Property { get; set; }

    }
}
