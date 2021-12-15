using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Entities.Entities
{
    public class PropertyFeature
    {
        [Key]
        public int IdPropertyFeature { get; set; }
        public int IdProperty { get; set; }
        public int IdFeature { get; set; }
        public string Value { get; set; }
        public bool Enabled { get; set; }

        public virtual Property Property { get; set; }
        public virtual Feature Feature { get; set; }

    }
}
