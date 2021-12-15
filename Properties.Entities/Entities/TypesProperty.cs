using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Entities.Entities
{
    public class TypesProperty
    {
        public int IdType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<Property> Property { get; set; }
    }
}
