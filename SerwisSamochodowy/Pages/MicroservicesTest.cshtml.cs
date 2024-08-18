using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Threading.Tasks;

public class MicroservicesTestModel : PageModel
{
    private readonly HttpClient _httpClient;

    public MicroservicesTestModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public string CarServiceData { get; set; }
    public string PartsWarehouseData { get; set; }

    public async Task OnGetAsync()
    {
        CarServiceData = await _httpClient.GetStringAsync("https://localhost:5003/microservices/carservice");
        PartsWarehouseData = await _httpClient.GetStringAsync("https://localhost:5003/microservices/partswarehouse");
    }
}
