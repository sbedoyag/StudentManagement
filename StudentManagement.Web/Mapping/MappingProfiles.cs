using AutoMapper;
using StudentManagement.Core.Entities;
using StudentManagement.Web.Services.DTOs;

namespace StudentManagement.Web.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Student, StudentViewModel>();
            //.ForMember(dest => dest.Document, opt => opt.MapFrom(src => src.Document))
            //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<Subject, SubjectViewModel>();
                //.ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
