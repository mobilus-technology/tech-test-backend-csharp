using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using WebApiProduct.Context;
using WebApiProduct.DbAll;
using WebApiProduct.Interface;
using WebApiProduct.Repository;
using WebApiProduct.Service;

namespace WebApiProduct;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ContextDbConnection>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SqlS")));
    
        var mongoClient = new MongoClient(Configuration.GetConnectionString("MongoConnection"));
        services.AddSingleton<IMongoClient>(mongoClient);

        services.AddScoped<IMongoDatabase>(provider =>
        {
            var mongoDatabase = mongoClient.GetDatabase("Product");
            return mongoDatabase;
        });
        services.AddScoped<IProductRepository, CompositeProductRepository>(provider =>
        {
            var sqlRepository = new SqlProductRepository(provider.GetRequiredService<ContextDbConnection>());
            var noSqlRepository = new NoSqlProductRepository(provider.GetRequiredService<IMongoDatabase>());

            return new CompositeProductRepository(sqlRepository, noSqlRepository);
        });

        services.AddScoped<IProductService, ProductService>();

        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi-Products", Version = "v1" });
        });
        services.AddSwaggerGen();
    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
       if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "webproductsAPI-V1");
        });

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
