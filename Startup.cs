using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Ctf.Repositories;
using Ctf.Controllers;
using Ctf.Utils;

namespace Ctf
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
            });


            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSignalR();
            services.AddAuthentication(Constants.COOKIE_NAME)
                .AddCookie(Constants.COOKIE_NAME);
            
            // Add repositories
            services.AddScoped<QuestRepository,QuestRepository>();
            services.AddScoped<ScoringRepository,ScoringRepository>();
            services.AddSingleton<FlagRepository,FlagRepository>();
            services.AddSingleton<TodoRepository, TodoRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseStaticFiles();// wwwroot
            app.UseAreaStaticFiles(); // Areas/{area}/wwwarearoot

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller:exists=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                
                endpoints.MapHub<ScoreHub>("/scoreHub");
            });
            // app.UseSignalR(routes =>
            // {
            //     routes.MapHub<ChatHub>("/chatHub");
            // });
        }
    }
}
