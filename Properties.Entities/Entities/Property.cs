using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Entities.Entities
{
    public class Property
    {
        [Key]
        public int IdProperty { get; set; }
        public int IdType { get; set; }
        public int IdOwner { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Area { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int Year { get; set; }
        public string MainImage { get; set; }
        public int Price { get; set; }
        public string CodeInternal { get; set; }
        public string Status { get; set; }
        public string UserProcess { get; set; }
        public DateTime DateTimeProcess { get; set; }

        public virtual Owner Owners { get; set; }
        public virtual TypesProperty TypesProperties { get; set; }
        public virtual IEnumerable<PropertyFeature> PropertyFeatures { get; set; }
        public virtual IEnumerable<PropertyImage> PropertyImages { get; set; }
        public virtual IEnumerable<PropertyPost> PropertyPosts { get; set; }
        public virtual IEnumerable<PropertySale> PropertySales { get; set; }
        public virtual IEnumerable<PropertyTrace> PropertyTraces { get; set; }


    }
}
