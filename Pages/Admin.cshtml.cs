using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using SerwisMotoryzacyjny.Areas.Identity.Data; // Importuj model u¿ytkownika

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
            // Pobieramy aktualnie zalogowanego u¿ytkownika
            var user = await _userManager.GetUserAsync(User);

            // Jeœli u¿ytkownik nie jest zalogowany, przekieruj na stronê logowania
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            // Sprawdzenie, czy u¿ytkownik ma rolê Admin
            if (user.Role != 1) // Zak³adamy, ¿e rola 1 to Admin
            {
                return Forbid(); // 403 - brak uprawnieñ
            }

            // Jeœli wszystko jest OK, renderujemy stronê
            return Page();
        }
    }
}
