using AutoMapper;
using FamilyIncomeApi.Models.Dtos.ExpenditureDtos;
using FamilyIncomeApi.Models.Entities;

namespace FamilyIncomeApi.Helpers
{
    public class FamilyIncomeProfile : Profile
    {
        public FamilyIncomeProfile()
        {
            CreateMap<Expenditure, ExpenditureDto>();
            CreateMap<Expenditure, ExpenditureDetailsDto>();
            CreateMap<ExpenditureCreateDto, Expenditure>();
            CreateMap<ExpenditureUpdateDto, Expenditure>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
