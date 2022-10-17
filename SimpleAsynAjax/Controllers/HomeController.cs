using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleAsynAjax.Models;
using Newtonsoft.Json;
using System.Net;
using System.Data;
using System.Threading;


namespace SimpleAsynAjax.Controllers
{

    public class HomeController : Controller
    {

        public ExampleDatabaseEntities db = new ExampleDatabaseEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ExampleTable example)
        {
            string message = "";
            try
            {
                db.ExampleTables.Add(example);
                db.SaveChanges();
                message = "new example added!";
            }
            catch(Exception msg)
            {
                message = msg.ToString();
            }

            return Json(new { Message = message, JsonRequestBehavior.AllowGet}, "Index");
        }

        public JsonResult GetExampleTable(ExampleTable example)
        {
            List<ExampleTable> tables = new List<ExampleTable>();
            try
            {
                tables = db.ExampleTables.ToList();
            }
            catch(Exception exception)
            {
                
            }

            return Json(tables, JsonRequestBehavior.AllowGet );
            //send message and json return 
        }
    }
}


