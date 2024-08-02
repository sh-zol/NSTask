
using AppDBContext.DBContext;
using AppServices;
using Domain.Core.Products.Contracts;
using Domain.Core.SiteSetting;
using Domain.Core.User.Contracts;
using Domain.Core.User.Entities;
using EF_Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Service;
using System.Text.Json.Serialization;

namespace NSTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<IPersonRepo, PersonRepo>();

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IPersonService, PersonService>();

            builder.Services.AddScoped<IProductAppService, ProductAppService>();
            builder.Services.AddScoped<IPersonAppService, PersonAppService>();
            builder.Services.AddScoped<IAppUserAppService, AppUserAppService>();

            #region Configuration 
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var sitesettings = config.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
            builder.Services.AddSingleton(sitesettings);
            #endregion

            #region Database 
            builder.Services.AddDbContext<AppDBContexts>(o=>o.UseSqlServer(sitesettings.SqlConfig.ConnectionString));
            #endregion

            #region Identity 
            builder.Services.AddIdentity<AppUser, IdentityRole<int>>(o =>
            {
                o.SignIn.RequireConfirmedAccount = false;
                o.Password.RequireDigit = true;
                o.Password.RequiredLength = 6;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireLowercase = false;
            }
            ).AddRoles<IdentityRole<int>>()
            .AddEntityFrameworkStores<AppDBContexts>();
            #endregion

            #region Log Config
            builder.Logging.ClearProviders();
            builder.Host.ConfigureLogging(loggingbuilder =>
            {
                loggingbuilder.ClearProviders();
            }).UseSerilog((context, config) =>
            {
                config.WriteTo.Seq("http://localhost:5341", Serilog.Events.LogEventLevel.Information);
            });
            #endregion

            #region Json Configuration

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

            #endregion

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
