using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace UsersApi.Services
{
    public class LogoutService
    {
        private readonly SignInManager<IdentityUser<int>> _signinManager;

        public LogoutService(SignInManager<IdentityUser<int>> signinManager)
        {
            _signinManager = signinManager;
        }
        public Result LogoutUser()
        {
            var resultIdentity = _signinManager.SignOutAsync();
            if (resultIdentity.IsCompletedSuccessfully) return Result.Ok();

            return Result.Fail("Logout falhou");
        }
    }


}
