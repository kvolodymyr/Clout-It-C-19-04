using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using vroom.AppData;
using vroom.AppDbContext;
using AutoMapper;
using vroom.MappingProfiles;

namespace vroom
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
            //ќЅя«ј“≈Ћ№Ќќ! запускаем AutoMapper при запуске приложени€
            services.AddAutoMapper(typeof(MappingProfile));
            //–егистрируем контекст базы данных в контейнере Dependency Injection в ConfigureServices методе в Startup.cs:
            services.AddDbContext<VroomDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Default")));
            //»змен€ем DefaultIdentity, добавл€ем поддержку ролей: IdentityRole
            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<VroomDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();
            services.AddScoped<IDBInitializer, DBInitializer>();
            services.AddMvc();

            services.AddControllersWithViews();
            services.AddRazorPages();
            //добавл€ем компил€цию файлов Razor в рантайме дл€ синхронизации проекта с браузером
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddCloudscribePagination();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDBInitializer dBInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Bike/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            dBInitializer.Initialize();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Bike}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
