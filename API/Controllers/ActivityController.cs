using CompanyInfo.Interfaces;
using CompanyInfo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyInfo.Controllers
{
    [Route("[controller]/[action]")]
    public class ActivityController : ControllerBase
    {
        private IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Atividade>>> GetAllAtividades()
        {
            try
            {
                var atividade = await _activityService.GetAllAsync();

                if (atividade.Count == 0)
                {
                    return NotFound("Atividades não encontradas.");
                }

                return Ok(atividade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
