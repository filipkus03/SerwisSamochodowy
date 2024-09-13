using Microsoft.AspNetCore.Mvc.RazorPages;
using SerwisMotoryzacyjny.Domain.Entities;
using SerwisMotoryzacyjny.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerwisMotoryzacyjny.Pages
{
    public class PartsModel : PageModel
    {
        private readonly IPartRepository _partRepository;

        public IEnumerable<Part> Parts { get; set; }

        public PartsModel(IPartRepository partRepository)
        {
            _partRepository = partRepository;
        }

        public async Task OnGetAsync()
        {
            Parts = await _partRepository.GetAllPartsAsync();
        }
    }
}
