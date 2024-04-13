using CompanyInfo.DTOs;
using CompanyInfo.Models;

namespace CompanyInfo.Interfaces
{
    public interface IActivityRepository
    {
        public Task<List<Atividade>> GetAllAsync();

        public Task Create(string code, string text);

        public Task<int> Create(Atividade activity);
    }
}
