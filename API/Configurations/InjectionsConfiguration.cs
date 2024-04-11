using CompanyInfo.Functions;
using CompanyInfo.Interfaces;
using CompanyInfo.Services;
using Microsoft.OpenApi.Models;

namespace CompanyInfo.Configurations
{
    public class InjectionsConfiguration
    {
        public static void Start(WebApplicationBuilder builder)
        {
            //ConfigureDatabase(builder);
            //ConfigureRepositories(builder.Services);
            ConfigureControllers(builder.Services);
            //ConfigureFunctions(builder.Services);
            ConfigureServices(builder.Services);
            ConfigureSwagger(builder.Services);
        }
        private static void ConfigureControllers(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
        }
        //private static void ConfigureDatabase(WebApplicationBuilder builder)
        //{
        //    builder.Services.AddDbContext<DBContext>(options =>
        //        options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        //            ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));
        //}

        //private static void ConfigureRepositories(IServiceCollection services)
        //{
        //    services.AddScoped<IAddressRepository, AddressRepository>();
        //}
        //private static void ConfigureFunctions(IServiceCollection services)
        //{
        //    services.AddScoped<IGetCompanyInfo, GetCompanyWithCnpjWS>;
        //}
        private static void ConfigureServices(IServiceCollection services)
        {
            ConfigureScopedServices(services);
        }



        private static void ConfigureScopedServices(IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
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
    }
}
