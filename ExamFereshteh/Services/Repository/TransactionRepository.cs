using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ExamFereshteh.DAL;
using ExamFereshteh.Models;


namespace ExamFereshteh.Services.Repository
{

    public class TransactionRepository : IRepository<Transaction>, ITransactionRepository
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

        public async Task<List<Tuple<string,decimal>>> GetAllWithEuroCurrency()
        {
            var Count = _table.Count();
            var ListWithEuroCurrancy = new List<Transaction>();
            List<Tuple<string, decimal>> result = new List<Tuple<string, decimal>>();
            for (int i = 0; i < Count; i++)
            {
               
                foreach (var p in _table)
                {
                    ListWithEuroCurrancy[i].Sku= p.Sku;
                    ListWithEuroCurrancy[i].Currency = "EUR";
                    if (p.Currency == "USD")
                    {
                        ListWithEuroCurrancy[i].Amount = p.Amount * (decimal) 0.736;
                    }
                    else if (p.Currency == "CAD")
                    {
                        ListWithEuroCurrancy[i].Amount = p.Amount * (decimal) 0.732;

                    }
                    else ListWithEuroCurrancy[i].Amount = p.Amount;

                }
            }

            var FinalList = ListWithEuroCurrancy.GroupBy(x => x.Sku).Select(p => new
            {
                productName = p.Key,
                totalAmountInEuro = p.Sum(d => d.Amount)
            }).ToList();

            foreach (var item in FinalList)
            {
                Tuple<string, decimal> productTuple =
                    new Tuple<string, decimal>(item.productName, item.totalAmountInEuro);
                result.Add(productTuple);
            }

            return result;

        }
    }

}
