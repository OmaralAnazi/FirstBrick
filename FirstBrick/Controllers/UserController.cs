using FirstBrick.Dtos.Requests;
using FirstBrick.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FirstBrick.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : BaseController
{
    private readonly UserManager<AppUser> _userManager;

    public UserController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetCurrentUser()
    {
        var user = await _userManager.FindByIdAsync(UserId);
        if (user == null)
        {
            return NotFound("User not found.");
        }

        // TODO: service logic, shouldnt be here:
        var userDto = new 
        {
            user.Id,
            user.Email,
            user.FirstName,
            user.LastName,
            user.PhoneNumber,
            user.Birthdate,
            user.CreatedAt,
        };

        return Ok(userDto);
    }


    // TODO: finish this endpoint
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserById([FromRoute] string userId)
    {
        return Ok(userId);
    }


    // TODO: finish this endpoint
    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateUser([FromRoute] string userId, [FromBody] UpdateUserDto updateUserDto)
    {
        return Ok(userId);
    }

}
