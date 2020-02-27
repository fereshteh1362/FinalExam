using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ExamFereshteh.DAL;

namespace ExamFereshteh.Services.Repository
{

    public class FakeRepository<T> : IRepository<T> where T : class
    {
        public DbContext _context { get; }
        public DbSet<T> _table { get; }

        public FakeRepository()
        {
            _context = new ProductContext();
            _table = _context.Set<T>();
        }


        public FakeRepository(DbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync().ConfigureAwait(false);
        }

        public async Task<T> GetById(object id)
        {
            return await _table.FindAsync(id).ConfigureAwait(false);
        }

        public async Task Add(T entity)
        {
            _table.Add(entity);
            await Save().ConfigureAwait(false);
        }

        public async Task Delete(object id)
        {
            T existing = await _table.FindAsync(id).ConfigureAwait(false);
            if (existing != null)
            {
                _table.Remove(existing);
                await Save().ConfigureAwait(false);
            }
        }

        public async Task Update(T entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await Save().ConfigureAwait(false);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }


    }

}