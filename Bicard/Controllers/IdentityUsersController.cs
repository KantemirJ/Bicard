using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bicard.Models;

[ApiController]
[Route("api/[controller]")]
public class IdentityUsersController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public IdentityUsersController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationModel model)
    {
        var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            // You may customize the response based on your needs
            return Ok(new { Message = "User registered successfully" });
        }

        return BadRequest(new { Errors = result.Errors });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            // You may customize the response based on your needs
            return Ok(new { Message = "Login successful" });
        }

        return Unauthorized(new { Message = "Invalid login attempt" });
    }
}
