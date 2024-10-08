﻿using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;

namespace Labb_1___Avancerad_fullstackutveckling.Services.IServices
{
    public interface IUserService
    {
        Task<UserDTO> GetUserByIdAsync(int userId);
        Task CreateUserAsync(CreateUserDTO user);
        Task UpdateUserAsync(UserDTO user);
        Task DeleteUserAsync(int userId);
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
    }
}
