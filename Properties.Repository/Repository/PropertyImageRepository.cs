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
    public class PropertyImageRepository : IPropertyImageRepository
    {
        private readonly ContextSQLServer _context;

        public PropertyImageRepository()
        {
            _context = new ContextSQLServer();
        }

        public async Task<Tuple<PropertyImage, bool>> AddAsync(PropertyImage entity)
        {
            try
            {
                var result = _context.PropertyImages.Add(entity);
                await _context.SaveChangesAsync();

                return Tuple.Create(result.Entity, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PropertyImage>> QueryAllAsync()
        {
            try
            {
                var result = await _context.PropertyImages.ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PropertyImage>> QueryByFilterAsync(Expression<Func<PropertyImage, bool>> whereCondition = null)
        {
            try
            {
                var result = await _context.PropertyImages.Where<PropertyImage>(whereCondition).ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PropertyImage> QueryByIdAsync(int id)
        {
            try
            {
                var result = await _context.PropertyImages.FindAsync(id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(PropertyImage entity)
        {
            try
            {
                var result = _context.PropertyImages.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
