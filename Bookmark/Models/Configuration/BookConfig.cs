using System;
using Bookmark.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Bookmark.Models
{
	internal class BookConfig : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> entity)
		{
			entity.HasOne(b => b.About)
				.WithMany(a => a.Books)
				.OnDelete(DeleteBehavior.Restrict);

			entity.HasData(
				new Book { BookId = 1, Title = "To Kill a Mocking Bird", Rating = 9, AboutId = 1, GenreId = 1, Date = "03/18" },
                new Book { BookId = 2, Title = "The Hunger Games", Rating = 7, AboutId = 2, GenreId = 1, Date = "02/09" },
                new Book { BookId = 3, Title = "The Glass Castle", Rating = 8, AboutId = 1, GenreId = 1, Date = "05/20" }
                );
		}
	}
}

