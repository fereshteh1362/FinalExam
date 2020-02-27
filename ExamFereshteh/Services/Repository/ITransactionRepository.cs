using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ExamFereshteh.Services.Repository
{
   public interface ITransactionRepository
    {
        Task<List<Tuple<string, decimal>>> GetAllWithEuroCurrency();
    }
}
