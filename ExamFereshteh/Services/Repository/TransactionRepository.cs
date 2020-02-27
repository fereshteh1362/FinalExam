using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ExamFereshteh.DAL;
using ExamFereshteh.Models;

namespace ExamFereshteh.Services.Repository
{
   
    public class TransactionRepository: IRepository<Transaction>, ITransactionRepository
    {
        public DbContext _context { get; }
        public DbSet<Transaction> _table { get; }

        public TransactionRepository()
        {
            _context = new ProductContext();
            _table = _context.Set<Transaction>();
        }

        
        public TransactionRepository(DbContext context)
        {
            _context = context;
            _table = _context.Set<Transaction>();
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _table.ToListAsync().ConfigureAwait(false);
        }

        public async Task<Transaction> GetById(object id)
        {
            return await _table.FindAsync(id).ConfigureAwait(false);
        }

        public async Task Add(Transaction entity)
        {
            _table.Add(entity);
            await Save().ConfigureAwait(false);
        }

        public async Task Delete(object id)
        {
            Transaction existing = await _table.FindAsync(id).ConfigureAwait(false);
            _table.Remove(existing);
            await Save().ConfigureAwait(false);
        }

        public async Task Update(Transaction entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await Save().ConfigureAwait(false);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Transaction>> GetAllWithEuroCurrency()
        {
            return await _table.ToListAsync().ConfigureAwait(false);

        }

    }
}