using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using BLL.Abstractions;
using BLL.Mapping;
using BLL.Services;
using DAL.Abstractions;
using DAL.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using ProjectAlefVinal.ActionFilters;
using ProjectAlefVinal.Mapping;
using ProjectAlefVinal.Models;
using ProjectAlefVinal.Validators;

namespace ProjectAlefVinal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddMvcCore(options =>
                {
                    options.Filters.Add(new ValidationFilter());
                })
                .AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssemblyContaining<Startup>();
                });

            services.AddCors(corsOptions =>
                {
                    corsOptions.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                });

            services.AddScoped<ICodeService, CodeService>();
            services.AddScoped<ICodeRepository, CodeRepository>();

            services.AddScoped<IValidator<CodeModel>, CodeModelValidator>();

            services.AddSingleton(CreateAutoMapperConfiguration().CreateMapper());
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.WithOrigins("http://localhost:3000/").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public static MapperConfiguration CreateAutoMapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
                cfg.AddProfile<MappingProfileModel>();
            });
        }
    }
}
