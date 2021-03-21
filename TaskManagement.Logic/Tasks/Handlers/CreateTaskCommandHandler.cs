using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TaskManagement.Logic.Interfaces;
using TaskManagement.Logic.Tasks.Commands;
using Task = TaskManagement.Core.Entities.Task;

namespace TaskManagement.Logic.Tasks.Handlers
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Tasks.Add(_mapper.Map<Task>(request));
            return result;
        }
    }
}