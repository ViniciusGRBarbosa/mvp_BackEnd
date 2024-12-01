using back_rdv.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace back_rdv.Controllers;


[Route("User")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> GetUserById()
    {

        var userName = await _context.Users.Where(x => x.Id == 15).Select(x => x.FirstName).ToListAsync();
        return Ok(userName);
    }

}