using AutoMapper;
using BeneExApp.Domain;
using BeneExApp.DTOs;

namespace BeneExApp.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Beneficiary, BeneficiaryRequestDto>().ReverseMap();
            CreateMap<Expenditure, ExpenditureRequestDto>().ReverseMap();
        }
    }
}