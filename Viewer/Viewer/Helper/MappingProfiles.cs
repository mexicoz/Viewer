using AutoMapper;
using Viewer.Dto;
using Viewer.Models;

namespace Viewer.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Author, AuthorDto>();
        }
    }
}
