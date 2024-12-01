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
    [HttpGet("{userId:long}")]
    public IActionResult GetUserById(long userId)
    {
        var userName =  _context.Users.Where(x => x.Id == userId).Select(x => new {
            x.FirstName,
            x.LastName,
            x.PhoneNumber,
            x.Email,
            Address = x.HasAddresses.Select(x => new {
                x.Address.Street,
                x.Address.Number,
                x.Address.Complement,
                x.Address.City,
                x.Address.Uf,
                x.Address.ZipCode,
            }).ToList()
        }).FirstOrDefault();

        if (userName is null) return BadRequest("Usuário não encontrado");

        return Ok(userName);
    }

}