using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChinookSystem.BLL;
using ChinookSystem.DAL;

#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
#endregion

namespace ChinookSystem
{
    public static class ChinookExtensions
    {
        public static void ChinookSystemBackendDependencies(this IServiceCollection services, 
            Action<DbContextOptionsBuilder> options)
        {
            // Register the DBContext class in Chinook2018 with the service collection
            services.AddDbContext<Chinook2018Context>(options);

            // Add any services that you create in the class library
            // using .AddTransient<t>(...)

            services.AddTransient<AboutServices>((serviceProvider) =>
                {
                    var context = serviceProvider.GetRequiredService<Chinook2018Context>();
                    // Create an instance of the service and return the instance
                    return new AboutServices(context);
                }
            );
        }
    }
}
