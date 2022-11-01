using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using SellerERP.Data;
using SellerERP.Repositories;
using SellerERP.Repositories.Interfaces;

namespace SellerERP;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers().AddNewtonsoftJson(s =>
        {
            s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        });

        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddRazorPages();

        services.AddDbContext<SellerERPContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SellerERPConnection")));

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<SeedingService>();

        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IModuleRepository, ModuleRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo { Title = "Seller ERP API", Version = "v1" });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeedingService seedingService)
    {
        app.UseSwagger();

        app.UseSwaggerUI(a =>
        {
            a.SwaggerEndpoint("/swagger/v1/swagger.json", "Seller ERP API V1");
            a.RoutePrefix = string.Empty;
        });

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            seedingService.Seed();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}