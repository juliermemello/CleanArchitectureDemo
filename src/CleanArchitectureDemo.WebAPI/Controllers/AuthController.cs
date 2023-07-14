using CleanArchitectureDemo.Domain.Enums;
using CleanArchitectureDemo.Domain.RequestModels;
using CleanArchitectureDemo.Domain.ResponseModels;
using CleanArchitectureDemo.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureDemo.WebAPI.Controllers;

public class AuthController : ApiControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly TokenService _tokenService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, TokenService tokenService, ILogger<AuthController> logger)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _logger = logger;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegistrationRequest request)
    {
        try
        {
            var user = new IdentityUser { UserName = request.Username, Email = request.Email };

            var userRoleExists = await _roleManager.RoleExistsAsync(RoleTypes.User.ToString());

            if (!userRoleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }

            var result = await _userManager.CreateAsync(user, request.Password);

            await _userManager.AddToRoleAsync(user, "User");

            var errors = result.Errors.Select(e => e.Description);

            if (result.Succeeded)
            {
                request.Password = string.Empty;

                return CreatedAtAction(nameof(Register), new { email = request.Email }, request);
            }
            
            return BadRequest(errors);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("token")]
    public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
    {
        try
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);

                if (user == null)
                    return Unauthorized();

                var userRoles = await _userManager.GetRolesAsync(user);

                var token = _tokenService.CreateToken(user, userRoles);

                return Ok(new AuthResponse
                {
                    Username = user.UserName,
                    Email = user.Email,
                    Token = token
                });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }

        return Unauthorized();
    }
}
