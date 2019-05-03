using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testt.Models;
namespace testt.Controllers
{
    public class testController : Controller
    {
        Database1Entities db = new Database1Entities();

        // GET: test
        public ActionResult Index()
        {
            var ans = db.book.OrderBy(m => m.Id).ToList();

            return View(ans);
        }

        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(book ans2)
        {
            db.book.Add(ans2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}