using LibraryManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingsController : ControllerBase
    {
        private readonly IBorrowingService _borrowingService;

        public BorrowingsController(
            IBorrowingService borrowingService)
        {
            _borrowingService = borrowingService;
        }

        // GET: api/borrowings
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var borrowings =
                await _borrowingService.GetAllBorrowingsAsync();

            return Ok(borrowings);
        }

        // GET: api/borrowings/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var borrowing =
                await _borrowingService.GetBorrowingByIdAsync(id);

            if (borrowing == null)
            {
                return NotFound("Borrowing record not found.");
            }

            return Ok(borrowing);
        }

        // POST: api/borrowings?bookId=1&memberId=1
        [HttpPost]
        public async Task<IActionResult> BorrowBook(
            int bookId,
            int memberId)
        {
            var result =
                await _borrowingService.BorrowBookAsync(
                    bookId,
                    memberId);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(new
            {
                result.Message,
                result.Borrowing
            });
        }

        // PUT: api/borrowings/1/return
        [HttpPut("{id}/return")]
        public async Task<IActionResult> ReturnBook(int id)
        {
            var result =
                await _borrowingService.ReturnBookAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }
    }
}