using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoAnCuoiKiNhom9.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string? Address { get; set; }
       
    }
}
