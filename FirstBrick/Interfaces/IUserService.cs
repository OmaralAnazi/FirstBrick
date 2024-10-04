using FirstBrick.Dtos.Requests;
using FirstBrick.Dtos.Responses;
using Microsoft.AspNetCore.Identity;

namespace FirstBrick.Interfaces;

public interface IUserService
{
    public Task<UserDto> GetUserByIdAsync(string id);
    public Task<(IdentityResult, UserDto)> UpdateUserByIdAsync(string id, UpdateUserDto updateUserDto);
}
