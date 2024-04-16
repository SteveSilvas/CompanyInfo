using AutoMapper;
using CompanyInfo.DTOs;
using CompanyInfo.Models;

namespace CompanyInfo.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CompanyInfoDTO, Empresa>()
                       .ForMember(dest => dest.BillingFree, opt => opt.MapFrom(src => src.Billing.Free))
                       .ForMember(dest => dest.BillingDatabase, opt => opt.MapFrom(src => src.Billing.Database));

            CreateMap<Empresa, CompanyInfoDTO>()
                .ForMember(dest => dest.Billing, opt => opt.MapFrom(src => new BillingDTO
                {
                    Free = src.BillingFree,
                    Database = src.BillingDatabase
                }));
        }
    }
}
