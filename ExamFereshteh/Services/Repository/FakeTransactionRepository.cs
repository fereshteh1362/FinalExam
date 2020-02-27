using ExamFereshteh.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamFereshteh.Services.Repository
{
    public class FakeTransactionRepository : IRepository<Transaction>, ITransactionRepository
    {
        List<Transaction> misTransacciones = new List<Transaction>();

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return misTransacciones;
        }

        public async Task<Transaction> GetById(object id)
        {
            return misTransacciones[(int)id];

        }

        public async Task Add(Transaction entity)
        {
            misTransacciones.Add(entity);
        }

        public async Task Delete(object id)
        {
            misTransacciones.RemoveAt((int)id);
        }

        public async Task Update(Transaction entity)
        {

            Transaction MyEntity = misTransacciones.Find(x => x.Id == entity.Id);
            if (MyEntity != null)
            {
                MyEntity = entity;
            }

        }

        public async Task Save()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Tuple<string, decimal>>> GetAllWithEuroCurrency()
        {
            throw new NotImplementedException();
        }
    }
}