using MediatR;
using TaskManagement.Logic.Tasks.Dto;

namespace TaskManagement.Logic.Tasks.Queries
{
    public class GetTaskByIdQuery : IRequest<TaskDto>
    {
        public int Id { get; set; }
        
    }
}