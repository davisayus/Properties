using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Properties.Contracts.Generics;
using Properties.Entities.Entities;

namespace Properties.Contracts.Repository
{
    public interface IOwnerRepository: IGenericRepositoryAddUpdate<Owner>, IGenericRepositoryQuery<Owner>
    {
    }
}
