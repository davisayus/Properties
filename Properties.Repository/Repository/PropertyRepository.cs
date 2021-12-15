using Microsoft.EntityFrameworkCore;
using Properties.Contracts.Repository;
using Properties.DataAccess.SQLServer;
using Properties.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Repository.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ContextSQLServer _context;

        public PropertyRepository()
        {
            _context = new ContextSQLServer();
        }

        public async Task<Tuple<Property, bool>> AddAsync(Property entity)
        {
            try
            {
                var result = _context.Properties.Add(entity);
                await _context.SaveChangesAsync();

                return Tuple.Create(result.Entity, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Property>> QueryAllAsync()
        {
            try
            {
                var result = await _context.Properties.ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Property>> QueryByFilterAsync(Expression<Func<Property, bool>> whereCondition = null)
        {
            try
            {
                var result = await _context.Properties.Where<Property>(whereCondition).ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Property> QueryByIdAsync(int id)
        {
            try
            {
                var result = await _context.Properties.FindAsync(id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Property entity)
        {
            try
            {
                var result = _context.Properties.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Property>> QueryBySqlStmtAsync(string sqlStmt)
        {
            try
            {
                var result = await _context.Properties.FromSqlRaw(sqlStmt).ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
