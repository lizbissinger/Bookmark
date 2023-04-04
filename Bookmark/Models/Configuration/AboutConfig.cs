using System;
using Bookmark.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookmark.Models
{
	internal class AboutConfig : IEntityTypeConfiguration<About>
	{
		public void Configure(EntityTypeBuilder<About> entity)
		{
			entity.HasData(
				new About { AboutId = 1, FirstName = "Elizabeth", LastName = "Bissinger" },
                new About { AboutId = 2, FirstName = "Jakob", LastName = "Brown" },
                new About { AboutId = 3, FirstName = "Modupeoluwa", LastName = "Daniel" },
                new About { AboutId = 4, FirstName = "Suzanne", LastName = "Matthey" }
                );
		}
	}
}

