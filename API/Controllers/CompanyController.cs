using CompanyInfo.DTOs;
using CompanyInfo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanyInfo.Controllers
{
    [Route("[controller]/[action]")]
    public class CompanyController : ControllerBase
    {
        private ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
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
    }
}
