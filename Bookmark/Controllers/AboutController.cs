using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bookmark.Models;
using Bookmark.Models.DomainModels;

namespace Bookmark.Controllers
{
    public class AboutController : Controller
    {
        private IRepository<About> abouts { get; set; }

        public AboutController(IRepository<About> rep) => abouts = rep;

        public ViewResult Index()
        {
            var options = new QueryOptions<About>
            {
                OrderBy = a => a.LastName
            };
            return View(abouts.List(options));
        }

        [HttpGet]
        public ViewResult Add() => View();

        [HttpPost]
        public IActionResult Add(About about)
        {
            if (ModelState.IsValid)
            {
                abouts.Insert(about);
                abouts.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(about);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id) => View(abouts.Get(id));

        [HttpPost]
        public RedirectToActionResult Delete(About about)
        {
            abouts.Delete(about);
            abouts.Save();
            return RedirectToAction("Index");
        }
    }
}

