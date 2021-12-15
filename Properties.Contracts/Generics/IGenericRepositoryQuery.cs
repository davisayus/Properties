using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Contracts.Generics
{
    public interface IGenericRepositoryQuery<T> where T : class
    {
        Task<T> QueryByIdAsync(int id);
        Task<List<T>> QueryAllAsync();
        Task<List<T>> QueryByFilterAsync(Expression<Func<T, bool>> whereCondition = null);
    }
}
