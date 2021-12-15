using Properties.Contracts.Generics;
using Properties.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Contracts.Repository
{
    public interface IPropertyRepository:IGenericRepositoryAddUpdate<Property>, IGenericRepositoryQuery<Property>, IGenericRepositoryQueryAdvance<Property>
    {
    }
}
