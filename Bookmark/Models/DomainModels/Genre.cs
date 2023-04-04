using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Bookmark.Models.DomainModels;

namespace Bookmark.Models.DomainModels
{
    public class Genre
    {
        public Genre() => Books = new HashSet<Book>();    // initialize navigation property

        public int GenreId { get; set; }                     // Primary key

        // no error messages included bc users won't be entering - this is so 
        // EF will generate a non-null nvarchar with length shorter than max
        [StringLength(10)]
        [Required()]
        public string Name { get; set; } = string.Empty;

        public ICollection<Book> Books { get; set; }    // Navigation property
    }
}


