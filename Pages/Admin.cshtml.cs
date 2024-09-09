using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using SerwisMotoryzacyjny.Areas.Identity.Data; // Importuj model u�ytkownika

namespace SerwisMotoryzacyjny.Pages
{
    [Authorize] // Wymagaj zalogowania
    public class AdminModel : PageModel
    {
        private readonly UserManager<SerwisMotoryzacyjnyUser> _userManager;

        public AdminModel(UserManager<SerwisMotoryzacyjnyUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Pobieramy aktualnie zalogowanego u�ytkownika
            var user = await _userManager.GetUserAsync(User);

            // Je�li u�ytkownik nie jest zalogowany, przekieruj na stron� logowania
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            // Sprawdzenie, czy u�ytkownik ma rol� Admin
            if (user.Role != 1) // Zak�adamy, �e rola 1 to Admin
            {
                return Forbid(); // 403 - brak uprawnie�
            }

            // Je�li wszystko jest OK, renderujemy stron�
            return Page();
        }
    }
}
