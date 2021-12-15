using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Contracts.Generics
{
    public interface IGenericRepositoryAddUpdate<T> where T : class
    {
        Task<Tuple<T,bool>> AddAsync(T entity);

        Task<bool> UpdateAsync(T entity);

    }
}
