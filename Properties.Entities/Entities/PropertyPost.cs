using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Entities.Entities
{
    public class PropertyPost
    {
        public int IdPropertyPost { get; set; }
        public DateTime DatePost { get; set; }
        public int IdProperty { get; set; }
        public bool Enabled { get; set; }
        public string UserProcess { get; set; }
        public DateTime DateTimeProcess { get; set; }
        public virtual Property Property { get; set; }

    }
}
