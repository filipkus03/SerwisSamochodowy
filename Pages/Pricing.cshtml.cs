using Microsoft.AspNetCore.Mvc.RazorPages;
using SerwisMotoryzacyjny.Domain.Entities;
using SerwisMotoryzacyjny.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YourNamespace.Pages
{
    public class PricingModel : PageModel
    {
        private readonly IPricingRepository _pricingRepository;

        public PricingModel(IPricingRepository pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public IEnumerable<Pricing> Pricings { get; set; }

        public async Task OnGetAsync()
        {
            Pricings = await _pricingRepository.GetAllPricingsAsync();
        }
    }
}
