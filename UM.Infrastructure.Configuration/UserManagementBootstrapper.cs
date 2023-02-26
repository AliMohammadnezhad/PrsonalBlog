using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UM.Application.Contract.User;
using UM.Application.User;
using UM.Domain.UserAgg;
using UM.Infrastructure.EFCore;
using UM.Infrastructure.EFCore.Repositories;

namespace UM.Infrastructure.Configuration
{
    public class UserManagementBootstrapper
    {
        public static void Config(IServiceCollection service,string connectionString)
        {
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IUserApplication, UserApplication>();


            service.AddDbContext<UserManagementDbContext>(option=> option.UseSqlServer(connectionString));
            
        }

    }
}