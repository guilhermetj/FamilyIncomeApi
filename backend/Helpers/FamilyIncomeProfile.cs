using AutoMapper;
using FamilyIncomeApi.Models.Dtos.CategoryDtos;
using FamilyIncomeApi.Models.Dtos.ExpenditureDtos;
using FamilyIncomeApi.Models.Dtos.RevenueDtos;
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

            CreateMap<Revenue, RevenueDto>();
            CreateMap<Revenue, RevenueDetailsDto>();
            CreateMap<RevenueCreateDto, Revenue>();
            CreateMap<RevenueUpdateDto, Revenue>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Category, CategoryDto>();
        }
    }
}
