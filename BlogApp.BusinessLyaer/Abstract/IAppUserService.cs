using BlogApp.EntityLayer.Dtos;
using BloggApp.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLyaer.Abstract
{
    public interface IAppUserService
    {
        public Task<IdentityResult> RegisterUserAsync(RegisterDto registerDto);
        public Task<SignInResult> LogInUserAsync(LoginDto loginDto);
        public Task LogOutUserAsync();
    }
}
