using Microsoft.AspNetCore.Identity;


namespace BlogApp.BusinessLayer.Helpers
{
    internal static class IdentityErrorHelper
    {
        public static IdentityError UserNotFound => new IdentityError
        {
            Code = "UserNotFound",
            Description = "Kullanıcı Bulunamadı "
        };

        public static IdentityError UsernameOrPasswordIsIncorrect => new IdentityError
        {
            Code = "UsernameOrPasswordIsIncorrect.",
            Description = "Kullanıcı Adı veya Şifre Hatalı"
        };

        public static IdentityError YourAccountIsLocked => new IdentityError
        {
            Code = "YourAccountIsLocked",
            Description = "3 Dakika Boyunca Giriş Yapamazsınız"
        };

        public static IdentityError UserRegistrationFailed => new IdentityError
        {
            Code = "UserRegistrationFailed",
            Description = "Kullanıcı Kayıt İşlemi Başarısız"
        };
    }
}
