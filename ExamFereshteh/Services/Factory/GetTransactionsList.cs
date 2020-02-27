using ExamFereshteh.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ExamFereshteh.Services.Factory
{
    public class GetTransactionsList:IGetTransactionsList
    {
        public List<Transaction> TransactionsList { get; set; }
        private transactions _transactions;
        public void GetListOfTransactions()
        {

            _transactions = new transactions();
            string path = @"http://quiet-stone-2094.herokuapp.com/transactions.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(transactions));
            using (StreamReader reader = new StreamReader(path))
            {
                _transactions = (transactions)serializer.Deserialize(reader);
            }

            foreach (var i in _transactions.transaction)
            {
                TransactionsList.Add(new Transaction()
                {
                    Sku = i.sku,
                    Amount = i.amount,
                    Currency = i.currency
                });
            }



        }

    }
}