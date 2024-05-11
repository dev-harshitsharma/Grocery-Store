using System.Security.Claims;

namespace API.Extensions
{
    //this class is reponsible for retriveing the e-mail id of the user
    public static class ClaimsPrincipleExtensions
    {
        public static string RetrieveEmailFromPrinciple(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Email);
        }
    }
}