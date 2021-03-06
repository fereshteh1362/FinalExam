﻿using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using ExamFereshteh.Models;
using ExamFereshteh.Services.Factory;
using ExamFereshteh.Services.Repository;
using ExamFereshteh.ViewModel;
using Newtonsoft.Json;

namespace ExamFereshteh.Controllers
{
    [HandleError(View = "Error")]
    public class TransactionController : Controller
    {
        private readonly IGetTransactionsList _transactionList;
        private readonly IRepository<Transaction> _repository;

        public TransactionController()
        {
            _repository = new TransactionRepository();
        }

        public TransactionController(IRepository<Transaction> repository, IGetTransactionsList getTransactionsList)
        {
            _repository = repository;
            _transactionList = getTransactionsList;
        }

        // GET: Transaction
        public async Task<string> Index()
        {
            return JsonConvert.SerializeObject(_transactionList.TransactionsList);
        }

        // GET: Transaction/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var transaction = await _repository.GetById(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transaction/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Sku,Amount,Currency")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(transaction);
                await _repository.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Transaction/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = await _repository.GetById(id);
           
            if (transaction == null)
            {
                return HttpNotFound();
            }

            return View(transaction);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Sku,Amount,Currency")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                await _repository.Update(transaction);
                await _repository.Save();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }

        // GET: Transaction/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = await _repository.GetById(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _repository.Delete(id);
            await _repository.Save();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> GetListOfProductWithEuroCurrency()
        {
            var transactionTuple= await ((ITransactionRepository)_repository).GetAllWithEuroCurrency();
            var vMList = new List<TransactionViewModel>();
            foreach (var item in transactionTuple)
            {
                var sku = item.Item1;
                var vmElement = new TransactionViewModel();
                vmElement.Sku = item.Item1;
                vmElement.Amount = item.Item2;
                vMList.Add(vmElement);


            }

            return View(vMList);

        }

       
    }
}
