using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Models
{
    public class Borrowing
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        [JsonIgnore]
        public Book? Book { get; set; }

        public int MemberId { get; set; }

        [JsonIgnore]
        public Member? Member { get; set; }

        public DateTime BorrowedDate { get; set; }

        public DateTime? ReturnedDate { get; set; }
    }
}