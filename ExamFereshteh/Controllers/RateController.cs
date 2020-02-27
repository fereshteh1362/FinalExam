using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using ExamFereshteh.Models;
using ExamFereshteh.Services.Factory;
using ExamFereshteh.Services.Repository;
using Newtonsoft.Json;

namespace ExamFereshteh.Controllers
{
    [HandleError(View = "Error")]
    public class RateController : Controller
    {
        private readonly IGateRatesList _ratesList;
        private readonly IRepository<Rate> _repository;

        public RateController()
        {
            
        }
        public RateController(IRepository<Rate> repository, IGateRatesList getRatesList)
        {
            _repository = repository;
            _ratesList = getRatesList;

        }

        // GET: Rate
        public async Task<string> Index()
        {
           
            
            return JsonConvert.SerializeObject( _ratesList.RatesList); 
        }

        // GET: Rate/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Rate rate = await _repository.GetById(id);
            if (rate == null)
            {
                return HttpNotFound();
            }
            return View(rate);
        }

        // GET: Rate/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: Rate/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RateAmount,From,To")] Rate rate)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(rate);
                await _repository.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Rate/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rate rate = await _repository.GetById(id);
            if (rate == null)
            {
                return HttpNotFound();
            }
            return View(rate);
        }

        // POST: Rate/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,RateAmount,From,To")] Rate rate)
        {
            if (ModelState.IsValid)
            {
                await _repository.Update(rate);
                await _repository.Save();
                return RedirectToAction("Index");
            }
            return View(rate); 
        }

        // GET: Rate/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rate rate = await _repository.GetById(id);
            if (rate == null)
            {
                return HttpNotFound();
            }
            return View(rate);
        }

        // POST: Rate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _repository.Delete(id);
            await _repository.Save();
            return RedirectToAction("Index");
        }

        
    }
}
