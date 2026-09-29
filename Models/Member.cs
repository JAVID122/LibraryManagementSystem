using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace LibraryManagementSystem.Models

{
    public class Member
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
    }
}
