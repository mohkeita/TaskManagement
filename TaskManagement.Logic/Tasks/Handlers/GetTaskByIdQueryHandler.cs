using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TaskManagement.Logic.Interfaces;
using TaskManagement.Logic.Tasks.Dto;
using TaskManagement.Logic.Tasks.Queries;

namespace TaskManagement.Logic.Tasks.Handlers
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTaskByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<TaskDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Tasks.Get(request.Id);
            return _mapper.Map<TaskDto>(result);
        }
    }
}