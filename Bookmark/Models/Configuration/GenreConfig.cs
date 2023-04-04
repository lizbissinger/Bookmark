using System;
using Bookmark.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookmark.Models
{
	internal class GenreConfig : IEntityTypeConfiguration<Genre>
	{
		public void Configure(EntityTypeBuilder<Genre> entity)
		{
			entity.HasData(
				new Genre { GenreId = 1, Name = "Fiction" },
                new Genre { GenreId = 1, Name = "Non-Fiction" },
                new Genre { GenreId = 1, Name = "Mystery" },
                new Genre { GenreId = 1, Name = "Romance" },
                new Genre { GenreId = 1, Name = "Thriller" },
                new Genre { GenreId = 1, Name = "Horror" },
                new Genre { GenreId = 1, Name = "Biography/Memoir" }
                );
		}
	}
}

