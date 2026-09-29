namespace Library_Management_System.Models
{
    public class Member
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
    }
}
