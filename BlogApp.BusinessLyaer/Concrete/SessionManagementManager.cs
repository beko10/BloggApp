using BlogApp.BusinessLayer.Helpers;
using BlogApp.BusinessLyaer.Abstract;
using BlogApp.EntityLayer.Dtos;
using BloggApp.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;


namespace BlogApp.BusinessLyaer.Concrete
{
    internal class SessionManagementManager : ISessionManagementService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        

        public SessionManagementManager(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        public async Task<IdentityResult> LogInUserAsync(LoginDto loginDto)
        {
            var hasUser = await _userManager.FindByEmailAsync(loginDto.Email);
            if (hasUser == null)
            {
                return IdentityResult.Failed(IdentityErrorHelper.UserNotFound);
            }
            var logInresult = await _signInManager.PasswordSignInAsync(hasUser!, loginDto.Password, loginDto.RememberMe, true);

            if (!logInresult.Succeeded)
            {
                return IdentityResult.Failed(IdentityErrorHelper.UsernameOrPasswordIsIncorrect);
            }

            if (logInresult.IsLockedOut)
            {
                return IdentityResult.Failed(IdentityErrorHelper.YourAccountIsLocked);
            }

            return IdentityResult.Success;
        }



        public async Task LogOutUserAsync()
        {
            await _signInManager.SignOutAsync();
        }



        public async Task<IdentityResult> RegisterUserAsync(RegisterDto registerDto)
        {

            var CreatedUser = new AppUser
            {
                Email = registerDto.Email,
                PhoneNumber = registerDto.Phone,
                UserName = registerDto.UserName,

            };
            var registerResult =  await _userManager.CreateAsync(CreatedUser, registerDto.Password);
            if (!registerResult.Succeeded)
            {
                return IdentityResult.Failed(IdentityErrorHelper.UserRegistrationFailed);
            }
            return IdentityResult.Success;  
        }

    }
}
