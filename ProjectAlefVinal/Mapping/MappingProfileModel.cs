using AutoMapper;
using BLL.Models;
using ProjectAlefVinal.Models;

namespace ProjectAlefVinal.Mapping
{
    public class MappingProfileModel : Profile
    {
        public MappingProfileModel()
        {
            CreateMap<CodeDto, CodeModel>();
            CreateMap<CodeModel, CodeDto>();
        }
    }
}
