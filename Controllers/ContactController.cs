using Microsoft.AspNetCore.Mvc;
using SerwisMotoryzacyjny.Domain.Entities;
using SerwisMotoryzacyjny.Domain.Interfaces;
using System.Threading.Tasks;

namespace SerwisMotoryzacyjny.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IActionResult> Index()
        {
            var contacts = await _contactRepository.GetAllAsync();
            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _contactRepository.AddAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }
    }
}
