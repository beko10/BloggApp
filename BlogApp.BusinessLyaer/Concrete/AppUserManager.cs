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
    internal class AppUserManager : IAppUserService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AppUserManager(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        public async Task<SignInResult> LogInUserAsync(LoginDto loginDto)
        {
            return await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, loginDto.RememberMe, true);
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
            return await _userManager.CreateAsync(CreatedUser, registerDto.Password);
        }

    }
}
