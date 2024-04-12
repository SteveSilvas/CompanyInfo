using CompanyInfo.DTOs;
using CompanyInfo.Models;

namespace CompanyInfo.Interfaces
{
    public interface IAtividadeRepository
    {
        public Task<List<Atividade>> GetAllAsync();
    }
}
