using System;
using Microsoft.EntityFrameworkCore;
using Bookmark.Models;
using Bookmark.Models.DomainModels;

namespace Bookmark.Models.DataLayer
{
	public class BookmarkContext : DbContext
	{
		public BookmarkContext(DbContextOptions<BookmarkContext> options)
			: base(options)
		{ }

		public DbSet<Genre> Genres { get; set; } = null!;

		public DbSet<About> Abouts { get; set; } = null!;

		public DbSet<Book> Books { get; set; } = null!;


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new GenreConfig());
			modelBuilder.ApplyConfiguration(new AboutConfig());
			modelBuilder.ApplyConfiguration(new BookConfig());
		}
	}
}

