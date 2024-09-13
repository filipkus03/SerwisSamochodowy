using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SerwisMotoryzacyjny.Domain.Interfaces;
using SerwisMotoryzacyjny.Domain.Entities;
using System.Threading.Tasks;

namespace SerwisMotoryzacyjny.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IContactRepository _contactRepository;

        public ContactModel(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [BindProperty]
        public Contact Contact { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _contactRepository.AddAsync(Contact);

            return RedirectToPage("Success");
        }

    }
}
