using AutoMapper;
using CareProviderAPI.Data.DTOs.AchievementDTOs;
using CareProviderAPI.Data.DTOs.CareProviderDTOs;
using CareProviderAPI.Data.DTOs.DepartmentDTOs;
using CareProviderAPI.Data.DTOs.ExperienceDTOs;
using CareProviderAPI.Data.DTOs.UserDTO;
using CareProviderAPI.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    
    {
        CreateMap<CreateCareProviderDto, CareProvider>();
        CreateMap<CareProvider, CareProviderDto>().ReverseMap();
        CreateMap<Department, DepartmentDto>().ReverseMap();
        CreateMap<Achievement, AchievementDto>().ReverseMap();
        CreateMap<Experience, ExperienceDto>().ReverseMap();
        CreateMap<User, LoginDTO>().ReverseMap();
        CreateMap<User, RegisterDTO>().ReverseMap();
        CreateMap<UpdateCareProviderDto, CareProvider>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

    }
}
