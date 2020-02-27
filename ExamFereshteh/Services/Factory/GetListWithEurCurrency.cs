using ExamFereshteh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamFereshteh.Services.Factory
{
    public class GetListWithEurCurrency:IGetListWithEurCurrency
    {
        public List<Transaction> TransactionsListWithEur { get; set; }
        public void GetListWithEuroCurrency()
        {
            var transactionList = new GetTransactionsList().TransactionsList;

            foreach (var element in TransactionsListWithEur)

            foreach (var item in transactionList )
            {
                element.Sku = item.Sku;
                element.Currency = "EUR";
                if (item.Currency == "USD")
                {
                    element.Amount = item.Amount * (decimal)0.736;
                }
                else if (item.Currency == "CAD")
                {
                    element.Amount = item.Amount * (decimal)0.732;
                }

                element.Amount = item.Amount;

            }
        }
    }
}