using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Interfaces;
using LibraryManagementSystem.Services.Interfaces;

namespace LibraryManagementSystem.Services
{
    public class BorrowingService : IBorrowingService
    {
        private readonly IBorrowingRepository _borrowingRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMemberRepository _memberRepository;

        public BorrowingService(
            IBorrowingRepository borrowingRepository,
            IBookRepository bookRepository,
            IMemberRepository memberRepository)
        {
            _borrowingRepository = borrowingRepository;
            _bookRepository = bookRepository;
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<Borrowing>> GetAllBorrowingsAsync()
        {
            return await _borrowingRepository.GetAllAsync();
        }

        public async Task<Borrowing?> GetBorrowingByIdAsync(int id)
        {
            return await _borrowingRepository.GetByIdAsync(id);
        }

        public async Task<(bool Success, string Message, Borrowing? Borrowing)>
            BorrowBookAsync(int bookId, int memberId)
        {
            // Check whether book exists
            var book = await _bookRepository.GetByIdAsync(bookId);

            if (book == null)
            {
                return (false, "Book not found.", null);
            }

            // Check whether member exists
            var member = await _memberRepository.GetByIdAsync(memberId);

            if (member == null)
            {
                return (false, "Member not found.", null);
            }

            // Check whether book is available
            if (!book.IsAvailable)
            {
                return (false, "Book is not available.", null);
            }

            // Create borrowing record
            var borrowing = new Borrowing
            {
                BookId = bookId,
                MemberId = memberId,
                BorrowedDate = DateTime.UtcNow,
                ReturnedDate = null
            };

            await _borrowingRepository.AddAsync(borrowing);

            // Book is no longer available
            book.IsAvailable = false;

            await _bookRepository.UpdateAsync(book);

            return (
                true,
                "Book borrowed successfully.",
                borrowing);
        }

        public async Task<(bool Success, string Message)>
            ReturnBookAsync(int borrowingId)
        {
            var borrowing =
                await _borrowingRepository.GetByIdAsync(borrowingId);

            if (borrowing == null)
            {
                return (false, "Borrowing record not found.");
            }

            // Prevent returning the same book twice
            if (borrowing.ReturnedDate != null)
            {
                return (false, "Book has already been returned.");
            }

            borrowing.ReturnedDate = DateTime.UtcNow;

            await _borrowingRepository.UpdateAsync(borrowing);

            // Make book available again
            var book =
                await _bookRepository.GetByIdAsync(borrowing.BookId);

            if (book != null)
            {
                book.IsAvailable = true;

                await _bookRepository.UpdateAsync(book);
            }

            return (true, "Book returned successfully.");
        }
    }
}