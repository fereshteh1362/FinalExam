using ExamFereshteh.Models;
using System.Collections.Generic;


namespace ExamFereshteh.Services.Factory
{
    public interface IGetTransactionsList
    {
        List<Transaction> TransactionsList { get; set; }
        void GetListOfTransactions();
    }
}