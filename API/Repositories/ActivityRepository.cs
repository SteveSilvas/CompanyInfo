using CompanyInfo.Contexts;
using CompanyInfo.Interfaces;
using CompanyInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyInfo.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly CompanyContext _companyContext;
        public ActivityRepository(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        public async Task<List<Atividade>> GetAllAsync()
        {
            return await _companyContext.Atividades.ToListAsync();
        }

        public Task Create(string code, string text)
        {
            Atividade activity = new Atividade
            {
                Code = code,
                Text = text
            };
            return Create(activity);
        }
        public async Task<int> Create(Atividade activity)
        {
            _companyContext.Atividades.Add(activity);
            await _companyContext.SaveChangesAsync();
            return activity.Id;
        }
    }
}
