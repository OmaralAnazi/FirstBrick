using FirstBrick.Attributes;
using FirstBrick.Dtos.Requests;
using FirstBrick.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstBrick.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : BaseController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetCurrentUser()
    {
        var userDto = await _userService.GetUserByIdAsync(UserId);
        return Ok(userDto);
    }

    [HttpGet("{userId}")]
    [RequireAdminRole]
    public async Task<IActionResult> GetUserById([FromRoute] string userId)
    {
        var userDto = await _userService.GetUserByIdAsync(userId);
        return Ok(userDto);
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateCurrentUser([FromBody] UpdateUserDto updateUserDto)
    {
        var (result, userDto) = await _userService.UpdateUserByIdAsync(UserId, updateUserDto);
        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok(userDto);
    }

    [HttpPut("{userId}")]
    [RequireAdminRole]
    public async Task<IActionResult> UpdateUserById([FromRoute] string userId, [FromBody] UpdateUserDto updateUserDto)
    {
        var (result, userDto) = await _userService.UpdateUserByIdAsync(userId, updateUserDto);
        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok(userDto);
    }
}
