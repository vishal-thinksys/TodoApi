using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Api.Contexts;
using Todo.Api.Entities;

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly TodoDbContext _toDoContext;

        public AccountController(TodoDbContext toDoContext)
        {
            _toDoContext = toDoContext;
        }
        [HttpPost]
        public IActionResult Login([FromBody] Login credential)
        {
            if (credential == null || string.IsNullOrEmpty(credential.UserName) || string.IsNullOrEmpty(credential.UserPassword))
            {
                return BadRequest("Invalid client request");
            }

            var user = _toDoContext.UserCredentials.SingleOrDefault(u => u.UserName == credential.UserName);

            if (user == null || user.UserPassword != credential.UserPassword)
            {
                return Unauthorized();
            }

            var users = _toDoContext.UserCredentials
                         .Include(x => x.UserRole)
                         .Where(x => x.UserName == credential.UserName && x.UserPassword == credential.UserPassword);

            // If using JWT for authentication, generate a token here
            // var token = GenerateJwtToken(user);

            // For demonstration purposes, we'll just return a success message
            return Ok("Login successful");
        }
    }
}
