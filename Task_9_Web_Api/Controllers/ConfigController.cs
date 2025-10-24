using Task_9_Web_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Task_9_Web_Api.Models;

namespace Task_9_Web_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly MySettings _mySettings;

        public ConfigController(IConfiguration configuration, IOptions<MySettings> options)
        {
            _configuration = configuration;
            _mySettings = options.Value;
        }

        [HttpGet]
        [Route("config")]
        public IActionResult GetConfig()
        {
   
            var manualSettings = new
            {
                ApplicationName = _configuration["MySettings:ApplicationName"],
                Version = _configuration["MySettings:Version"],
                MaxItems = _configuration.GetValue<int>("MySettings:MaxItems")
            };

           
            var optionsSettings = _mySettings;

            return Ok(new
            {
                Manual = manualSettings,
                OptionsPattern = optionsSettings
            });
        }
    }
}
