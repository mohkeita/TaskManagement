using AutoMapper;
using TaskManagement.Core.Entities;
using TaskManagement.Logic.Tasks.Commands;
using TaskManagement.Logic.Tasks.Dto;

namespace TaskManagement.Logic.Tasks.MappingProfiles
{
    public class TaskMappingProfile : Profile
    {
        public TaskMappingProfile()
        {
            CreateMap<CreateTaskCommand, Task>();
            CreateMap<UpdateTaskCommand, Task>();
            CreateMap<Task, TaskDto>();
        }
    }
}