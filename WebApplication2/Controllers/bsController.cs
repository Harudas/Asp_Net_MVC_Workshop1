using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class bsController : Controller
    {
        // GET: bs
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SearchOrder()
        {
            return View();
        }
        [HttpPost()]
        public ActionResult Index(FormCollection form)

        {
            Models.Class1 test = new Models.Class1();
            string ans= form["name"];
            string ans2 = form["age"];
            test.Gett(ans);
            test.Gett2(ans2);

            ViewBag.Name = test.Gett(ans); 
            ViewBag.Age = test.Gett2(ans2);
            return View("SearchOrder");
        }
        [HttpPost()]
        public ActionResult SearchOrder(FormCollection form)

        {
            ViewBag.Name2 = form["name2"];
            ViewBag.Age2 = form["age2"];
            return View("Index");
        }
    }
}