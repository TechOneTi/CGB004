using Microsoft.Extensions.DependencyInjection;
using CGB004.Application.Interfaces;
using CGB004.Application.Services;
using CGB004.Data.Code.Api;
using CGB004.Data.Code.Business.SAFX;
using CGB004.Data.Code.Interfaces;
using CGB004.Data.Configuration;
using CGB004.Data.Code.Business.Inconsistencia;
using CGB004.Data.Model.Config;

namespace CGB004.ConsoleApp.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            //Hosted Service
            services.AddHostedService<ConsoleService>();                        

            //AppSetting Services
            services.AddSingleton<AppSettings, AppSettings>();

            //Log Services
            services.AddSingleton<ILogApplicationService, LogApplicationService>();

            services.AddSingleton<RequestInfo>();

            services.AddSingleton<IApi, Api>();
            //Aplicattion Service            
            services.AddTransient<ISAFXService, SAFXService>();
            services.AddTransient<IInconsistenciaService, InconsistenciaService>();
            services.AddTransient<ISAFXBLL, SAFXBLL>();
            services.AddTransient<ISAFXDAL, SAFXDAL>();
            services.AddTransient<IInconsistenciaBLL, InconsistenciaBLL>();
            services.AddTransient<IInconsistenciaDAL, InconsistenciaDAL>();

            return services;
        }
    }
}
