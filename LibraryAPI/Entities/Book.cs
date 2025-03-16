using System.ComponentModel.DataAnnotations;
using LibraryAPI.Enums;

namespace LibraryAPI.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author is required.")]
        [StringLength(100, ErrorMessage = "Author cannot be longer than 100 characters.")]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "ISBN is required.")]
        [StringLength(20, ErrorMessage = "ISBN cannot be longer than 20 characters.")]
        public string ISBN { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status is required.")]
        public int StatusId { get; set; } = (int)BookStatus.OnShelf;
        public BookStatus Status => (BookStatus)StatusId;
    }
}