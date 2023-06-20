using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceA.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        public string[] GetPerson()
        {
            return new string[] {"ServiceA" ,"YuanSai", "LiuYiFei" };
        }


    }
}
