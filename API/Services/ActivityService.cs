using CompanyInfo.DTOs;
using CompanyInfo.Functions;
using CompanyInfo.Interfaces;
using CompanyInfo.Models;

namespace CompanyInfo.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IAtividadeRepository _activityRepository;
        public ActivityService(IAtividadeRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<List<Atividade>> GetAllAsync()
        {
            var atividades = await _activityRepository.GetAllAsync();

            return atividades;
        }
    }
}
