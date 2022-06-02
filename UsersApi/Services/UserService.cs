using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Data.Dtos;
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
            if (result.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao cadastrar usuario");
        }
    }
}
