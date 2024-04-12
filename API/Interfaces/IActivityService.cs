using CompanyInfo.DTOs;
using CompanyInfo.Models;

namespace CompanyInfo.Interfaces
{
    public interface IActivityService
    {
        public Task<List<Atividade>> GetAllAsync();
    }
}
