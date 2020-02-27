using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamFereshteh.Models;

namespace ExamFereshteh.Services.Repository
{
   public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAllWithEuroCurrency();
    }
}
