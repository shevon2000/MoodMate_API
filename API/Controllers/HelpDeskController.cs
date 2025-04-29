using Microsoft.AspNetCore.Mvc;
using Application.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelpDeskController : ControllerBase
    {
        private readonly HelpDeskService _helpDeskService;

        public HelpDeskController(HelpDeskService helpDeskService)
        {
            _helpDeskService = helpDeskService;
        }

        [HttpGet]
        public IActionResult GetHelpTips()
        {
            var tips = _helpDeskService.GetHelpTips();
            return Ok(tips);
        }
    }
}
