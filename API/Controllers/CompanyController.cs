using CompanyInfo.DTOs;
using CompanyInfo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanyInfo.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CompanyController : ControllerBase
    {
        private ICompanyService _companyService;
        private IActivityRepository _atividadeRepository;
        public CompanyController(ICompanyService companyService, IActivityRepository atividadeRepository)
        {
            _companyService = companyService;
            _atividadeRepository = atividadeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CompanyInfoDTO>> GetByCnpj(string cnpj)
        {
            try
            {
                CompanyInfoDTO companyInfo = await _companyService.GetCompanyInfoAsync(cnpj);

                if (companyInfo == null)
                {
                    return NotFound("Empresa não encontrada.");
                }

                return Ok(companyInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyInfoDTO>>> GetAll()
        {
            try
            {
                List<CompanyInfoDTO> companyInfo = await _companyService.GetAllAsync();

                if (companyInfo.Count == 0)
                {
                    return NotFound("Empresas não encontradas.");
                }

                return Ok(companyInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost] 
        public async Task<IActionResult> Create(CompanyInfoDTO company)
        {
            try
            {
                await _companyService.Create(company);

                return Ok("Empresa cadastrada com sucesso.");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
