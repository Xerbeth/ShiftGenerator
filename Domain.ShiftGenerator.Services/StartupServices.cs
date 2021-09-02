#region Referencias
using Domain.ShiftGenerator.BussinesLayer;
using Domain.ShiftGenerator.BussinesLayer.Implementation;
using Domain.ShiftGenerator.BussinesLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
#endregion Referencias

namespace Domain.ShiftGenerator.Services
{
    public class StartupServices
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IShiftsBL, ShiftsBL>();            
            StartupBusinessLayer.ConfigureServices(services, connectionString);
        }
    }
}
