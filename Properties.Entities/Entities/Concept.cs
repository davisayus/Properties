using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Entities.Entities
{
    public class Concept
    {
        [Key]
        public int IdConcept { get; set; }
        public string Description { get; set; }
        public string UserProcess { get; set; }
        public DateTime DateTimeProcess { get; set; }
    }
}
