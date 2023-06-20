using Microsoft.AspNetCore.Mvc;

namespace ServiceB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        public string[] GetPerson()
        {
            return new string[] {"ServiceB" ,"YuanSai", "LiuYiFei" };
        }


    }
}
