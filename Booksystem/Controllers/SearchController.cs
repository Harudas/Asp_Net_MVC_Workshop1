using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Booksystem.Models;

namespace Booksystem.Controllers
{
    public class SearchController : Controller
    {

        Database1Entities db = new Database1Entities();
        // GET: Search
        public ActionResult Index()
        {
            var user = db.Table;
            return View(user);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Table newtable)
        {
            db.Table.Add(newtable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}