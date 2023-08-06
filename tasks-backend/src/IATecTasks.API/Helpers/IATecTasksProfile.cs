using AutoMapper;
using IATecTasks.Application.Dtos;
using IATecTasks.Application.Dtos.User;
using IATecTasks.Domain;
using IATecTasks.Domain.Identity;

namespace IATecTasks.API.Helpers
{
    public class IATecTasksProfile : Profile
    {
        public IATecTasksProfile()
        {
            CreateMap<ETask, ETaskUpdateDto>().ReverseMap();
            CreateMap<ETask, ETaskCreateDto>().ReverseMap();
            CreateMap<ETask, ETaskListDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }
    }
}
