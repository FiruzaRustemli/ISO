using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ISOCertificate.DAL;
using ISOCertificate.Email;
using ISOCertificate.Models;
using ISOCertificate.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ISOCertificate
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
            services.AddSingleton(AutoMapperConfig.CreateMapper());
            //services.AddAutoMapper(typeof(Startup));
            services.AddMvc().AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<CertificateDbContext>(options =>
            //  options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            options.UseSqlServer(Configuration.GetSection("ConnectionString").Value,
                        sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly("ISOCertificate");
                            sqlOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(3), new List<int>());
                        }));
  

            
            services.AddSession();
            services.AddIdentity<ApplicationUser, IdentityRole>(option =>
            {
                option.Lockout.AllowedForNewUsers = true;
                option.Lockout.MaxFailedAccessAttempts = 3;
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(15);
                option.Password.RequireDigit = true;
                option.Password.RequiredLength = 6;

                option.User.RequireUniqueEmail = true;
            })
           .AddEntityFrameworkStores<CertificateDbContext>()
           .AddDefaultTokenProviders();

            services.Configure<EmailConfiguration>(Configuration.GetSection("EmailConfiguration"));
            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            CertificateDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseSession();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });

            DbInitializer.Seed(context, userManager, roleManager).Wait();
        }
    }
}
