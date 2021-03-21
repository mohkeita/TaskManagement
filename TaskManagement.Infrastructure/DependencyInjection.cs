using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Infrastructure.Repositories;
using TaskManagement.Logic.Interfaces;

namespace TaskManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
        
    }
}