using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceA.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HealthController : ControllerBase
    {

        [HttpGet]
        public string CheckHealth()
        {
            Console.WriteLine($"健康检查_ServiceA_【{DateTime.Now:yyyy/MM/dd HH:mm:ss}】");
            return "ServiceA-OK";
        }
    }
}
