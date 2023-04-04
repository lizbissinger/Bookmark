using System;
using Microsoft.AspNetCore.Mvc;
using Bookmark.Models;
using Bookmark.Models.DomainModels;

namespace Bookmark.Components
{
	public class GenreFilter : ViewComponent
	{
		private IRepository<Genre> data { get; set; }

		public GenreFilter(IRepository<Genre> rep) => data = rep;

		public IViewComponentResult Invoke()
		{
			var genres = data.List(new QueryOptions<Genre>
			{
				OrderBy = g => g.GenreId
			});
			return View(genres);
		}
	}
}

