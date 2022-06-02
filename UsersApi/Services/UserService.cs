using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Data.Dtos;
using UsersApi.Data.Requests;
using UsersApi.Models;

namespace UsersApi.Services
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser<int>> _manager;
        public UserService(IMapper mapper, UserManager<IdentityUser<int>> manager)
        {
            _mapper = mapper;
            _manager = manager;
        }
        public Result Create(CreateUserDto createDto)
        {
            var user = _mapper.Map<User>(createDto);
            var userIdentity = _mapper.Map<IdentityUser<int>>(user);
            var result = _manager.CreateAsync(userIdentity, createDto.Password);
            if (result.Result.Succeeded)
            {
                var code = _manager.GenerateEmailConfirmationTokenAsync(userIdentity).Result;
                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("Falha ao cadastrar usuario");
        }

        public Result ActiveUser(ActiveUserRequest request)
        {
            var userIdentity = _manager.Users.FirstOrDefault(u => u.Id == request.UserId);
            var identityResult = _manager.ConfirmEmailAsync(userIdentity, request.ActiveCode).Result;
            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Falha ao ativar conta de usuario");
        }
    }
}
