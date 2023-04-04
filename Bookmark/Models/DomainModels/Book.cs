using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Bookmark.Models.DomainModels;

namespace Bookmark.Models.DomainModels;

public class Book
{
    public int BookId { get; set; }                    // Primary key

    [StringLength(200, ErrorMessage = "Title may not exceed 200 characters.")]
    [Required(ErrorMessage = "Please enter a book title.")]
    public string Title { get; set; } = string.Empty;

    [Range(1, 5, ErrorMessage = "Class rating must be between 1 and 5.")]
    [Required(ErrorMessage = "Please enter a rating 1-5.")]
    public int? Number { get; set; }

    [Display(Name = "Date")]
    [RegularExpression("^[0-100]*$", ErrorMessage = "Please enter numbers only for date.")]
    [StringLength(6, MinimumLength = 6, ErrorMessage = "Date book was logged must be 6 characters long, mm/yyyy.")]
    [Required(ErrorMessage = "Please enter a date.")]
    public string Date { get; set; } = string.Empty;

    public int AboutId { get; set; }                  // Foreign key property
    [ValidateNever]
    public About About { get; set; } = null!;       // Navigation property

    public int GenreId { get; set; }                      // Foreign key property
    [ValidateNever]
    public Genre Genre { get; set; } = null!;               // Navigation property
}


