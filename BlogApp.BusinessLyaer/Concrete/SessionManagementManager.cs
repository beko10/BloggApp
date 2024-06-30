using BlogApp.BusinessLyaer.Abstract;
using BlogApp.EntityLayer.Dtos;
using BloggApp.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return IdentityResult.Failed(new IdentityError
                {
                    Code = "UserNotFound",
                    Description = "Kullanıcı Bulunamadı "
                });
            }
            var logInresult = await _signInManager.PasswordSignInAsync(hasUser!, loginDto.Password, loginDto.RememberMe, true);

            if (!logInresult.Succeeded)
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Code = "UsernameOrPasswordIsIncorrect.",
                    Description = "Kullanıcı Adı veya Şifre Hatalı"
                });
            }

            if (logInresult.IsLockedOut)
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Code = "YourAccountIsLocked",
                    Description = "3 Dakika Boyunca Giriş Yapamazsınız"
                });
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
                return IdentityResult.Failed(new IdentityError
                {
                    Code= "UserRegistrationFailed",
                    Description = "Kullanıcı Kayıt İşlemi Başarısız"
                });
            }
            return IdentityResult.Success;  
        }

    }
}
