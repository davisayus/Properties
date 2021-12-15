using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Entities.Dtos
{
    public class FilterPropertiesDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AreaFrom { get; set; }
        public int AreaTo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int YearFrom { get; set; }
        public int YearTo { get; set; }
        public List<FilterFeaturesDto> Features { get; set; }
    }
}
