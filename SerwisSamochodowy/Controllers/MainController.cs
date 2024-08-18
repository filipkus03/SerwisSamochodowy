using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SerwisSamochodowy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : ControllerBase
    {
        // Możesz dodać logikę, aby komunikować się z mikroserwisami tutaj

        [HttpGet("status")]
        public ActionResult<string> GetStatus()
        {
            return Ok("Serwis Samochodowy działa.");
        }

        // Możesz dodać więcej metod, aby interagować z mikroserwisami
    }
}
