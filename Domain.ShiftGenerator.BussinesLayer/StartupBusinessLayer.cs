#region Referecias
using Domain.ShiftGenerator.DAL.Implementation;
using Domain.ShiftGenerator.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
#endregion Referencias

namespace Domain.ShiftGenerator.BussinesLayer
{
    public class StartupBusinessLayer
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IShiftsRepository, ShiftsRepository>();            
        }
    }
}
