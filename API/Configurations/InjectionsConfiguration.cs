using CompanyInfo.Contexts;
using CompanyInfo.Functions;
using CompanyInfo.Interfaces;
using CompanyInfo.Mappings;
using CompanyInfo.Repositories;
using CompanyInfo.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace CompanyInfo.Configurations
{
    public class InjectionsConfiguration
    {
        public static void Start(WebApplicationBuilder builder)
        {
            ConfigureDatabase(builder);
            ConfigureRepositories(builder.Services);
            ConfigureServices(builder.Services);
            ConfigureControllers(builder.Services);
            ConfigureFunctions(builder.Services);
            ConfigureSwagger(builder.Services);
            ConfigureAutoMapper(builder.Services);
        }

        private static void ConfigureDatabase(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<CompanyContext>(options =>
                options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IActivityXCompanyRepository, ActivityXCompanyRepository>();
            services.AddScoped<IQsaRepository, QsaRepository>();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            ConfigureScopedServices(services);
        }

        private static void ConfigureScopedServices(IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IActivityService, ActivityService>();
        }
        private static void ConfigureControllers(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
        }

        private static void ConfigureFunctions(IServiceCollection services)
        {
            services.AddScoped<IGetCompanyInfo, GetCompanyByCnpj>();
        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CompanyInfo",
                    Description = "Application to search for detailed company information from the CNPJ.",
                    Contact = new OpenApiContact
                    {
                        Name = "Steve Silva",
                        Url = new Uri("https://github.com/SteveSilvas")
                    },
                });
            });
        }

        private static void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
