using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace LibraryManagementSystem.Models;



    public class Book
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Author { get; set; } = string.Empty;

        [Range(1000, 2100)]
        public int PublishedYear { get; set; }

        public bool IsAvailable { get; set; } = true;
    [JsonIgnore]
    public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();

    }

