using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TaskManagement.Logic.Interfaces;
using TaskManagement.Logic.Tasks.Commands;
using Task = TaskManagement.Core.Entities.Task;

namespace TaskManagement.Logic.Tasks.Handlers
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public UpdateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<int> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Tasks.Update(_mapper.Map<Task>(request));
            return result;
        }
    }
}