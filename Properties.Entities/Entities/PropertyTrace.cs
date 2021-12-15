using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Entities.Entities
{
    public class PropertyTrace
    {
        public int IdPropertyTrace { get; set; }
        public DateTime DateTrace { get; set; }
        public int IdConcept { get; set; }
        public string Description { get; set; }
        public int IdProperty { get; set; }
        public string UserProcess { get; set; }
        public DateTime DateTimeProcess { get; set; }
        public virtual Property Property { get; set; }

    }
}
