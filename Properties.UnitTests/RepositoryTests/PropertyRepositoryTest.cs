using Properties.Contracts.Repository;
using Properties.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Properties.UnitTests.RepositoryTests
{
    public class PropertyRepositoryTest : IPropertyRepository
    {
        private List<Property> _properties;

        public PropertyRepositoryTest()
        {
            _properties = new List<Property>();
        }

        public Task<Tuple<Property, bool>> AddAsync(Property entity)
        {

            entity.IdProperty = _properties.Count + 1;
            _properties.Add(entity);

            return Task.FromResult(Tuple.Create(entity, true));

        }

        public Task<List<Property>> QueryAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Property>> QueryByFilterAsync(Expression<Func<Property, bool>> whereCondition = null)
        {
            throw new NotImplementedException();
        }

        public Task<Property> QueryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Property>> QueryBySqlStmtAsync(string sqlStmt)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Property entity)
        {
            throw new NotImplementedException();
        }
    }
}
