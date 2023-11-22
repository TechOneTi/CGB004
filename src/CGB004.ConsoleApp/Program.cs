using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CGB004.ConsoleApp.Configuration;


static class Program
{
    public static IConfigurationRoot Configuration { get; private set; }

    static async Task Main(string[] args)
    {
        
        var host = CreateHostBuilder(args).Build();       
        await host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      (IHostBuilder)Host.CreateDefaultBuilder(args)
       .ConfigureAppConfiguration((hostingContext, configuration) =>
       {

           configuration.Sources.Clear();

           configuration
                       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                       .AddCommandLine(args);

           IConfigurationRoot configurationRoot = configuration.Build();

           Configuration = configurationRoot;


       }).ConfigureServices((services) =>
       {
           //services.AddCors(options =>
           //{
           //    options.AddDefaultPolicy(builder =>
           //    {
           //        builder.WithOrigins("https://localhost:3000", "http://localhost:3000")
           //                            .AllowAnyHeader()
           //                            .AllowAnyMethod();
           //    });
           //});
           services.RegisterServices();
           services.AddSingleton(Configuration);
       });
       



    public static void Configure(IApplicationBuilder app)
    {   

        // Allow CORS for any origin, method or header
        //app.UseCors(policy =>
        //        policy.AllowAnyOrigin()
        //        .AllowAnyMethod()
        //        .AllowAnyHeader());
    }
}