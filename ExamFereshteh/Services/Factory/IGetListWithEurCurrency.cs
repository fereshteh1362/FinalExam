using ExamFereshteh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamFereshteh.Services.Factory
{
   public interface IGetListWithEurCurrency
    {
        List<Transaction> TransactionsListWithEur { get; set; }
        void GetListWithEuroCurrency();
    }
}
