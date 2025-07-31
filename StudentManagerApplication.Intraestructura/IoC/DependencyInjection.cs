using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentManagerApplication.Applicaction.IRepository;
using StudentManagerApplication.Applicaction.IService;
using StudentManagerApplication.Applicaction.Service;
using StudentManagerApplication.Intraestructura.Data;
using StudentManagerApplication.Intraestructura.Repository;

namespace StudentManagerApplication.Intraestructura.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register the DbContext with SQL Server
            services.AddDbContext<ApplicationDbContextDB>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Register the repository and service
            services.AddScoped<IRepositoryStudents, RepositoryStudents>();
            services.AddScoped<IServiceStudents, ServiceStudents>();
            return services;
        }
    }
}
