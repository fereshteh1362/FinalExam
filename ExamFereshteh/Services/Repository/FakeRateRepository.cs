using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ExamFereshteh.Models;

namespace ExamFereshteh.Services.Repository
{
    public class FakeRateRepository : IRepository<Rate>, ITransactionRepository
    {
        List<Rate> misRates = new List<Rate>();

        public async Task Add(Rate entity)
        {
            misRates.Add(entity);
        }

        public async Task Delete(object id)
        {
            misRates.RemoveAt((int)id);
        }

        public async Task<IEnumerable<Rate>> GetAll()
        {
            return misRates;
        }

        public async Task<Rate> GetById(object id)
        {
            return misRates[(int)id];
        }

        public async Task Save()
        {
            throw new NotImplementedException();
        }

        public async Task Update(Rate entity)
        {
            Rate MyEntity = misRates.Find(x => x.Id == entity.Id);
            if (MyEntity != null)
            {
                MyEntity = entity;
            }
        }

        public Task<IEnumerable<Transaction>> GetAllWithEuroCurrency()
        {
            throw new NotImplementedException();
        }
    }
}