using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace Core.Entities.Identity
{
    //This class is responsible for the schema of the AppUser
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }

        public int IsAdmin {get;set;}
    }
}