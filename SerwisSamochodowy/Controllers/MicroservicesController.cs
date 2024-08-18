using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace SerwisSamochodowy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MicroservicesController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public MicroservicesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("carservice")]
        public async Task<IActionResult> GetCarServiceData()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7096/api/vehicles");
            return Content(response);
        }

        [HttpGet("partswarehouse")]
        public async Task<IActionResult> GetPartsWarehouseData()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7097/api/parts");
            return Content(response);
        }
    }
}
