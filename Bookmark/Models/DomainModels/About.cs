using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Bookmark.Models.DomainModels
{
    public class About
    {
        public About() => Books = new HashSet<Book>();   // initialize navigation property

        public int AboutId { get; set; }                    // Primary key

        [Display(Name = "First Name")]
        [StringLength(100, ErrorMessage = "First name may not exceed 100 characters.")]
        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "Last name may not exceed 100 characters.")]
        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; } = string.Empty;

        public ICollection<Book> Books { get; set; }       // Navigation property

        // read-only display property
        public string FullName => $"{FirstName} {LastName}";
    }
}


