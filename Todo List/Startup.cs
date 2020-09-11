using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Todo_List.DAL.Entities;
using Todolist.BLL.Abstract;
using Todolist.BLL.RoleManager;
using Todolist.BLL.UserManager;
using TodoList.DAL.EntitiyFramework;


namespace Todo_List
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

            string connection = @"Data Source=DESKTOP-Q5C30EP\SQLEXPRESS;Initial Catalog=todolist;Integrated Security=True";
            
            services.AddAuthentication("CookieAuthentication").AddCookie("CookieAuthentication",
                config =>
                {
                    config.Cookie.Name = "TodoListAuthenticaiton";
                    config.LoginPath = "/Home/Login";
                });

            services.AddScoped<TodoListDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddDbContext<TodoListDbContext>(options => options.UseSqlServer(connection));
            services.AddScoped<UserManager>();
            services.AddScoped<RoleManager>();
            services.AddControllersWithViews();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<TodoListDbContext>();
                context.Database.EnsureCreated();
            }

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
            app.UseStaticFiles();

            app.UseRouting();

            // Kimsin?
            app.UseAuthentication();

            // Yetkin var mı?
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Dashboard}/{id?}");
            });
        }
    }
}
