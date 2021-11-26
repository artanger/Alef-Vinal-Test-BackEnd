using AutoMapper;
using BLL.Models;
using DAL.Models;

namespace BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Code, CodeDto>();
            CreateMap<CodeDto, Code>();
        }
    }
}
