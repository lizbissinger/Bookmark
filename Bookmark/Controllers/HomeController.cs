using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookmark.Models;
using Bookmark.Models.DomainModels;

namespace Bookmark.Controllers;

public class HomeController : Controller
{
    private IRepository<Book> books { get; set; }

    public HomeController(IRepository<Book> bookRep) => books = bookRep;

    public ViewResult Index(int id)
    {
        var bookOptions = new QueryOptions<Book>
        {
            Includes = "About, Genre"
        };

        if (id == 0)
        {
            bookOptions.OrderBy = b => b.GenreId;
            bookOptions.ThenOrderBy = b => b.Date;
        }
        else
        {
            bookOptions.Where = b => b.GenreId == id;
            bookOptions.OrderBy = b => b.Date;
        }

        var bookList = books.List(bookOptions);

        ViewBag.Id = id;
        return View(bookList);
    }
}

