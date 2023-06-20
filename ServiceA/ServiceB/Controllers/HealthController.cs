using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HealthController : ControllerBase
    {

        [HttpGet]
        public string CheckHealth()
        {
            Console.WriteLine($"健康检查_ServiceB_【{DateTime.Now:yyyy/MM/dd HH:mm:ss}】");
            return "ServiceB-OK";
        }
    }
}
