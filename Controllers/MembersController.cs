using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        // GET: api/members
        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            var members =
                await _memberService.GetAllMembersAsync();

            return Ok(members);
        }

        // GET: api/members/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberById(int id)
        {
            var member =
                await _memberService.GetMemberByIdAsync(id);

            if (member == null)
            {
                return NotFound("Member not found.");
            }

            return Ok(member);
        }

        // POST: api/members
        [HttpPost]
        public async Task<IActionResult> AddMember(Member member)
        {
            var createdMember =
                await _memberService.AddMemberAsync(member);

            return CreatedAtAction(
                nameof(GetMemberById),
                new { id = createdMember.Id },
                createdMember);
        }

        // PUT: api/members/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(
            int id,
            Member member)
        {
            var result =
                await _memberService.UpdateMemberAsync(id, member);

            if (!result)
            {
                return NotFound("Member not found.");
            }

            return NoContent();
        }

        // DELETE: api/members/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var result =
                await _memberService.DeleteMemberAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}