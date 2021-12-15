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
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ContextSQLServer _context;

        public OwnerRepository()
        {
            _context = new ContextSQLServer();
        }

        public async Task<Tuple<Owner, bool>> AddAsync(Owner entity)
        {
            try
            {
                var result = _context.Owners.Add(entity);
                await _context.SaveChangesAsync();

                return Tuple.Create(result.Entity,true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Owner>> QueryAllAsync()
        {
            try
            {
                var result = await _context.Owners.ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Owner>> QueryByFilterAsync(Expression<Func<Owner, bool>> whereCondition = null)
        {
            try
            {
                var result = await _context.Owners.Where<Owner>(whereCondition).ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Owner> QueryByIdAsync(int id)
        {
            try
            {
                var result = await _context.Owners.FindAsync(id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Owner entity)
        {
            try
            {
                var result = _context.Owners.Update(entity);
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
