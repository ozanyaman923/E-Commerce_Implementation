using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.EfEntities;
using Scalar.AspNetCore;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());
            });

            builder.Services.AddControllers();
            //builder.Services.AddSingleton<IProductService,ProductManager>();
            //builder.Services.AddSingleton<IProductDal, EfProductDal>();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();
            app.MapGet("/", () => Results.Redirect("scalar/v1"));
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                
              
            }
            app.MapOpenApi();
            app.MapScalarApiReference();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            
                


            app.Run();
        }
    }
}
 