using System.Collections.Generic;
using MediatR;
using TaskManagement.Logic.Tasks.Dto;

namespace TaskManagement.Logic.Tasks.Queries
{
    public class GetAllTasksQuery : IRequest<List<TaskDto>>
    {
        
    }
}