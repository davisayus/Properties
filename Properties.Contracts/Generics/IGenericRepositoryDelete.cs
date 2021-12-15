using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Contracts.Generics
{
    public interface IGenericRepositoryDelete<T> where T : class
    {
        Task<bool> DeleteAsync(T entity);
    }
}
