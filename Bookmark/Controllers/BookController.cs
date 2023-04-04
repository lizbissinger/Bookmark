using Microsoft.AspNetCore.Mvc;
using Bookmark.Models;
using System.Security.Claims;
using Bookmark.Models.DomainModels;

namespace Bookmark.Controllers
{
    public class BookController : Controller
    {
        private IRepository<Book> books { get; set; }
        private IRepository<About> abouts { get; set; }
        private IRepository<Genre> genres { get; set; }

        public BookController(IRepository<Book> bookRep,
            IRepository<About> aboutRep, IRepository<Genre> genresRep)
        {
            books = bookRep;
            abouts = aboutRep;
            genres = genresRep;
        }

        public RedirectToActionResult Index() => RedirectToAction("Index", "Home");

        [HttpGet]
        public ViewResult Add()
        {
            this.LoadViewBag("Add");
            return View("AddEdit", new Book());
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            this.LoadViewBag("Edit");
            var b = this.GetBook(id);
            return View("AddEdit", b);
        }

        [HttpPost]
        public IActionResult Add(Book b)
        {
            bool isAdd = b.BookId == 0;

            if (ModelState.IsValid)
            {
                if (isAdd)
                    book.Insert(b);
                else
                    books.Update(b);
                books.Save();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                string operation = (isAdd) ? "Add" : "Edit";
                this.LoadViewBag(operation);
                return View("AddEdit", b);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var b = this.GetBook(id);
            return View(b);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Book b)
        {
            books.Delete(b);
            books.Save();
            return RedirectToAction("Index", "Home");
        }

        // private helper methods
        private Book GetBook(int id)
        {
            var bookOptions = new QueryOptions<Book>
            {
                Includes = "About, Genre",
                Where = b => b.BookId == id
            };
            return books.Get(bookOptions) ?? new Book();
        }
        private void LoadViewBag(string operation)
        {
            ViewBag.Genres = genres.List(new QueryOptions<Genre>
            {
                OrderBy = b => b.GenreId
            });
            ViewBag.Abouts = abouts.List(new QueryOptions<About>
            {
                OrderBy = a => a.LastName
            });
            ViewBag.Operation = operation;
        }
    }
}


