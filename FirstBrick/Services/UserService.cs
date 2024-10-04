using FirstBrick.Dtos.Requests;
using FirstBrick.Dtos.Responses;
using FirstBrick.Entities;
using FirstBrick.Exceptions;
using FirstBrick.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FirstBrick.Services;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;

    public UserService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<UserDto> GetUserByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id) ?? throw ApiExceptions.UserNotFound;
        var userDto = new UserDto(user);
        return userDto;
    }

    public async Task<(IdentityResult, UserDto)> UpdateUserByIdAsync(string id, UpdateUserDto updateUserDto)
    {
        var user = await _userManager.FindByIdAsync(id) ?? throw ApiExceptions.UserNotFound;

        user.FirstName = updateUserDto.FirstName ?? user.FirstName;
        user.LastName = updateUserDto.LastName ?? user.LastName;
        user.PhoneNumber = updateUserDto.PhoneNumber ?? user.PhoneNumber;

        var result = await _userManager.UpdateAsync(user);
        var userDto = new UserDto(user);

        return (result, userDto);
    }
}
