using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIRSHOP.BL.IRepositories;

namespace UIRSHOP.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private DbSet<T> _table;

        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public async Task Delete(int id)
        {
            var data = await Get(id);
            if (data is not null)
            {
                _table.Remove(data);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<T> Post(T entity)
        {
            if (entity != null)
            {
                await _table.AddAsync(entity);
                await _db.SaveChangesAsync();
            }
            return entity;
        }

        public async Task<T> Update(int id, T entity)
        {
            var data = await Get(id);
            if (data is null)
                return null;

            _db.Entry(data).CurrentValues.SetValues(entity);
            await _db.SaveChangesAsync();
            return data;
        }
    }
}
