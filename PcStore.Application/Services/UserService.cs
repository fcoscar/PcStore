using Microsoft.Extensions.Logging;
using PcStore.Application.Contract;
using PcStore.Application.Core;
using PcStore.Application.Dtos.User;
using PcStore.Infrastructure.Interfaces;

namespace PcStore.Application.Services;

public class UserService : IUserService
{
    private readonly ILogger<UserService> logger;
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository, ILogger<UserService> logger)
    {
        this.userRepository = userRepository;
        this.logger = logger;
    }

    public async Task<ServiceResult> GetUsers()
    {
        var result = new ServiceResult();
        try
        {
            result.Data = await GetUser();
        }
        catch (Exception e)
        {
            result.Message = "Error obteniendo usuarios";
            result.Success = false;
            logger.Log(LogLevel.Error, $"{result.Message}", e.ToString());
        }

        return result;
    }

    private async Task<List<UserGetDto>> GetUser()
    {
        var usersList = new List<UserGetDto>();
        try
        {
            usersList = (from users in await userRepository.GetAll()
                select new UserGetDto
                {
                    Id = users.Id,
                    Nombre = users.Nombre,
                    Correo = users.Correo,
                    Telefono = users.Telefono,
                    IsAdmin = users.IsAdmin,
                    Password = users.Password,
                    FechaCreacion = users.FechaCreacion
                }).ToList();
        }
        catch (Exception e)
        {
            logger.Log(LogLevel.Error, "Error obteniendo carros", e.ToString());
        }

        return usersList;
    }
}