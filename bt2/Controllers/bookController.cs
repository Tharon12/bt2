using bt2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bt2.Controllers
{
    public class bookController : Controller
    {
        // GET: book
      
        public ActionResult Listbook()
        {
            var books = new List<string>();
            books.Add("cuon sach thu 1");
            books.Add("cuon sach thu 2");
            books.Add("cuon sach thu 3");
            ViewBag.books= books;
            return View();
        }
        public ActionResult Listbookmodel()
        {
            var books = new List<book>();
            books.Add(new book(1,"cuon sach thu 1", "tac gia1","/Content/images/IMG_0486.JPG"));
            books.Add(new book(2,"cuon sach thu 2","tac gia2", "/Content/images/IMG_0487.JPG"));
            books.Add(new book(3,"cuon sach thu 3","tac gia3", "/Content/images/IMG_0488.JPG"));
            ViewBag.books = books;

            return View(books);
        }
        public ActionResult editbook(int id)
        {
            var books = new List<book>();
            books.Add(new book(1, "cuon sach thu 1", "tacgia1", "/Content/images/IMG_0486.JPG"));
            books.Add(new book(2, "cuon sach thu 2", "tacgia2", "/Content/images/IMG_0487.JPG"));
            books.Add(new book(3, "cuon sach thu 3", "tacgia3", "/Content/images/IMG_0488.JPG"));
            book book = new book();       
            foreach(book b in books)
            {
                if(b.Id==id)
                {
                    book = b;
                    break;
                }
                if(book==null)
                {
                    return HttpNotFound();
                }
            }
            return View(book);
        }
        [HttpPost, ActionName("editbook")]
        [ValidateAntiForgeryToken]
        public ActionResult editbook(int id, string title, string author, string img_cover )
        {
            var books = new List<book>();
            books.Add(new book(1, "cuon sach thu 1", "tacgia1", "/Content/images/IMG_0486.JPG"));
            books.Add(new book(2, "cuon sach thu 2", "tacgia2", "/Content/images/IMG_0487.JPG"));
            books.Add(new book(3, "cuon sach thu 3", "tacgia3", "/Content/images/IMG_0488.JPG"));
            book bk = new book();
            if (id == null)
            {
                return HttpNotFound();
            }
            foreach (book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = title;
                    b.Author = author;
                    b.Img_cover = img_cover;
                    bk = b;
                    break;
                }
             
            }
            return View("Listbookmodel",books);
        }
        public ActionResult createbook()
        {
            return View();
        }
        [HttpPost, ActionName("createbook")]
        [ValidateAntiForgeryToken]
        public ActionResult createbook([Bind(Include = "id, title, author ,img_cover")]book book)
        {
            var books = new List<book>();
            books.Add(new book(1, "cuon sach thu 1", "tacgia1", "/Content/images/IMG_0486.JPG"));
            books.Add(new book(2, "cuon sach thu 2", "tacgia2", "/Content/images/IMG_0487.JPG"));
            books.Add(new book(3, "cuon sach thu 3", "tacgia2", "/Content/images/IMG_0488.JPG"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch
            {
                {
                    ModelState.AddModelError("", "error data");
                }
            }
            return View("Listbookmodel", books);
        }
        public ActionResult delete(int id)
        {
            var books = new List<book>();
            books.Add(new book(1, "cuon sach thu 1", "tacgia1", "/Content/images/IMG_0486.JPG"));
            books.Add(new book(2, "cuon sach thu 2", "tacgia2", "/Content/images/IMG_0487.JPG"));
            books.Add(new book(3, "cuon sach thu 3", "tacgia2", "/Content/images/IMG_0488.JPG"));
            book b = new book();
            foreach (book i in books)
            {
                if (i.Id == id)
                {
                    b = i;
                    break;
                }
            }
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, string name, string author, string image)
        {
            var books = new List<book>();
            books.Add(new book(1, "cuon sach thu 1", "tacgia1", "/Content/images/IMG_0486.JPG"));
            books.Add(new book(2, "cuon sach thu 2", "tacgia2", "/Content/images/IMG_0487.JPG"));
            books.Add(new book(3, "cuon sach thu 3", "tacgia3", "/Content/images/IMG_0488.JPG"));
            if (id == null)
            {
                return HttpNotFound();
            }
            foreach (book b in books)
            {
                if (b.Id == id)
                {
                    books.Remove(b);

                    break;
                }
            }
            return View("ListbookModel", books);
        }

    }
}