using Entities.ErrorModels;
using Entities.Models;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;

using Repositories.Context;
using Repositories.Repositories.Repositories.BaseRepo;
using Repositories.Repositories.Repositories.Employee;
using Repositories.Repositories.Repositories.RepositoryManager;
using Repositories.Repositories.Repositories.StudentRepo;
using Repositories.Repositories.Repositories.WantRepo;

using Services.Services.EmployeeServices;
using Services.Services.PaymentServices;
using Services.Services.ScheduledJobServices;
using Services.Services.ServiceManager;
using Services.Services.StudentServices;
using Services.Services.WantsServices;
using System;
using System.Reflection;
using System.Text;
using YazRehProje.ContextFactory;
using static System.Formats.Asn1.AsnWriter;

namespace YazRehProje.Extensions
{
    public static class ServicesExtansions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration) => services.AddDbContext<YazContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlCon")));

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddHostedService<ScheduledJob>();
            services.AddResponseCaching();//ÖN BELLEĞE ALMA
            services.AddScoped<IEmployeeRepositories, EmployeeRepositories>();
            services.AddScoped<IStudentRepositories, StudentRepositories>();
            services.AddScoped<IWantRepositories, WantRepositories>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddScoped<IStudentServices, StudentServices>();
            services.AddScoped<IWantServices, WantServices>();
            services.AddScoped<IServiceManager, ServiceManager>();
            //services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IScopedService, ScopedService>();
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));//FOTOĞRAF EKLEME


           
            services.AddScoped<IPaymentService, PaymentService>(); // IPaymentService ve StripePaymentService örnek bir servis ve servis arayüzüdür.
            return services;
        }
    

        //BU METOD OLUCAK MI BİLMİYORUM DENEMEK LAZIM
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeatures = context.Features.Get<IExceptionHandlerFeature>();
                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode=context.Response.StatusCode,
                        Message=contextFeatures.Error.Message
                    }.ToString());
                });
            });
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<YazContext>().AddDefaultTokenProviders();
            //   services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("EmailConfirmationPolicy", policy =>
            //        policy.RequireAuthenticatedUser()
            //              .RequireClaim("IsEmailConfirmed", "false"));
            //});
            
        }

        //public static void ConfigureJwt(this IServiceCollection services,IConfiguration configuration)
        //{
        //    var jwtSettings = configuration.GetSection("JwtSetting");
        //    var secretKey = jwtSettings["secretKey"];

        //    services.AddAuthentication(opt =>
        //    {
        //        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //    }).AddJwtBearer(options =>
        //    {
        //        options.TokenValidationParameters = new TokenValidationParameters
        //        {

        //            ValidateIssuer = true,
        //            ValidateAudience = true,
        //            ValidateLifetime = true,
        //            ValidateIssuerSigningKey = true,
        //            ValidIssuer = jwtSettings["validIssuer"],
        //            ValidAudience = jwtSettings["validAudience"],
        //            IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        //        };
        //    });
           
        //}

        //public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        //{
        //    YazContext context = app
        //        .ApplicationServices
        //        .CreateScope()
        //        .ServiceProvider
        //        .GetRequiredService<YazContext>();

        //    if (context.Database.GetPendingMigrations().Any())
        //    {
        //        context.Database.Migrate();
        //    }
        //}


    }
}
