using ExamFereshteh.Services.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamFereshteh.Controllers
{
    public class ErrorController : Controller
    {
        
        ActionResult filterExceptionContext;
        // GET: ExceptionHandler
        public ActionResult Index()
        {
            return RedirectToAction("Error");
        }
        public ActionResult Error()
        {
            return View(filterExceptionContext);
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            var errorLog = new ErrorLog();
            if (filterContext.Exception is InvalidOperationException)
            {
                //Logging Errors 
                var errorMessage = filterContext.Exception.Message;
                var controllerName = filterContext.RouteData.Values["controller"].ToString();
                var actionName = filterContext.RouteData.Values["action"].ToString();
               // errorLog.WriteLog(errorMessage, controllerName, actionName);
              

               var model = new HandleErrorInfo(filterContext.Exception,
                    controllerName, actionName);


                filterContext.Result = new ViewResult
                {
                    ViewName = "Error",
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                    TempData = filterContext.Controller.TempData
                };

            }

            filterExceptionContext = filterContext.Result;
        }

    }
}
