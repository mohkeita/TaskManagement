using MediatR;

namespace TaskManagement.Logic.Tasks.Commands
{
    public class DeleteTaskCommand : IRequest<int>
    {
        public int Id { get; set; }
        
    }
}