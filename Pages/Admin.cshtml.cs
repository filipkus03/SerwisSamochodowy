using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using SerwisMotoryzacyjny.Areas.Identity.Data; 

namespace SerwisMotoryzacyjny.Pages
{
    [Authorize] 
    public class AdminModel : PageModel
    {
        private readonly UserManager<SerwisMotoryzacyjnyUser> _userManager;

        public AdminModel(UserManager<SerwisMotoryzacyjnyUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            if (user.Role != 1) 
            {
                return Forbid(); 
            }

            return Page();
        }
    }
}
