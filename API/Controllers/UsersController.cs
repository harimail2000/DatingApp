using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // /api/Users
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        // [HttpGet("{userName}")]
        // public async Task<ActionResult<AppUser>> GetUserName(string name)
        // {
        //     var query=  await _context.Users.AsQueryable();
        //     query = query.Where(q=> q.UserName == name);
        //     List<AppUser> username1 = query.ToList();
        //     return username1;

        // }
    }
}