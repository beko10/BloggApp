using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BlogApp.API.Extensions
{
    public static class ModelStateExtensions
    {
        public static void AddModelStateErrorList(this ModelStateDictionary modelState , IEnumerable<IdentityError> errors)
        {
            foreach (var errorItem in errors.ToList())
            {
                modelState.AddModelError(string.Empty,errorItem.Description);
            }
        }
    }
}
