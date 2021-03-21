using TaskManagement.Logic.Interfaces;

namespace TaskManagement.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ITaskRepository taskRepository)
        {
            Tasks = taskRepository;
        }
        public ITaskRepository Tasks { get; }
    }
}