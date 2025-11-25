using AutoMapper;
using SMDCheckSheet.Models;
using SMDCheckSheet.Dtos;

namespace SMDCheckSheet.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountReadDto>();
            CreateMap<AccountCreateDto, Account>();
            CreateMap<AccountUpdateDto, Account>();
        }
    }
}
