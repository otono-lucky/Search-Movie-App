using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Movie_App.Context;

namespace Movie_App.Extension
{
    public static class ConfigureServices
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.
            UseSqlServer(configuration.GetConnectionString("DBConnection")));

            

           

        }
    }
}
