using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingApp.Business.Operations.Setting;

namespace OnlineShoppingApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingService _settingService;


        public SettingsController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        //Taking care of those with admin authority
        [HttpPatch]
        [Authorize(Roles ="Admin")]

        public async Task<IActionResult> ToggleMaintenence()
        {
            await _settingService.ToggleMaintenence();

            return Ok();
        }
    }
}
