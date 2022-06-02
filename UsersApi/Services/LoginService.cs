using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsersApi.Data.Requests;

namespace UsersApi.Services
{
    public class LoginService
    {
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        public LoginService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result LoginUser (LoginRequest request)
        {
            var result = _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false );
            if (result.Result.Succeeded) return Result.Ok();
            return Result.Fail("Login Falhou");
        }
    }
}
