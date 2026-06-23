using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Core.Utilities.Security.Encryption;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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
           
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            var tokenOptionsSection = builder.Configuration.GetSection("TokenOptions");
            var tokenOptions = new Core.Utilities.Security.JWT.TokenOptions
            {
                Audience = tokenOptionsSection["Audience"],
                Issuer = tokenOptionsSection["Issuer"],
                SecurityKey = tokenOptionsSection["SecurityKey"],
                AccessTokenExpiration = int.TryParse(tokenOptionsSection["AccessTokenExpiration"], out var exp) ? exp : 0
            };
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });

            var app = builder.Build();
            app.MapGet("/", () => Results.Redirect("scalar/v1"));
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {


            }
            app.MapOpenApi();
            app.MapScalarApiReference();
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();




            app.Run();
        }
    }
}
