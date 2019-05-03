using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Book_final.Models;
using PagedList;
namespace Book_final.Controllers
{
    public class HomeController : Controller
    {
        db_BookEntities db = new db_BookEntities();
        int pagesize=5;
        // GET: Home
        public ActionResult Index(int page=1)
        {
            int currentPage=page < 1 ? 1 :page;
            var book = db.Book_data.OrderByDescending(m => m.BOOK_BOUGHT_DATE).ToList();
            var result=book.ToPagedList(currentPage,pagesize);
            return View(result);

            //show Book_data 內的資料 遞減排序
           // var book = db.Book_data.OrderByDescending(m => m.BOOK_BOUGHT_DATE).ToList();
            //return View(book);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book_data book)
        {
            db.Book_data.Add(book);
            db.SaveChanges(); //存到資料庫
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Book_id)
        {

            var book_id = db.Book_data.Where(m=>m.BOOK_ID==Book_id).FirstOrDefault();
            db.Book_data.Remove(book_id);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Book_id)
        {

            var book_id = db.Book_data.Where(m => m.BOOK_ID == Book_id).FirstOrDefault();
            return View(book_id);
        }

        [HttpPost]
        public ActionResult Edit(Book_data book)//抓表單資料
        {
            int Book_id = book.BOOK_ID;
            // book_id為要修改的資料
            var book_id = db.Book_data.Where(m => m.BOOK_ID == Book_id).FirstOrDefault();
            book_id.BOOK_NAME = book.BOOK_NAME;
            book_id.BOOK_CLASS_NAME = book.BOOK_CLASS_NAME;
            book_id.BOOK_AUTHOR = book.BOOK_AUTHOR;
            book_id.BOOK_BOUGHT_DATE = book.BOOK_BOUGHT_DATE;
            book_id.BOOK_PUBLISHER = book.BOOK_PUBLISHER;
            book_id.BOOK_NOTE = book.BOOK_NOTE;
            book_id.BOOK_STATUS = book.BOOK_STATUS;
            book_id.BOOK_KEEPER = book.BOOK_KEEPER;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult search(string searching)
        {
            //show Book_data 內的資料 遞減排序
            var book = db.Book_data.Where(x => x.BOOK_NAME.Contains(searching) || searching == null).ToList();
            return View(book);
        }

    }
}