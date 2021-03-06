using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GestionDesAbsencesMigration.Models.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using GestionDesAbsencesMigration.services;
using GestionDesAbsencesMigration.ServicesImpl;
using GestionDesAbsencesMigration.Services;
using Rotativa.AspNetCore;
using Wkhtmltopdf.NetCore;

namespace GestionDesAbsencesMigration
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

            //var connectionString = @"Server=db;Database=GestionDesAbsencesMigration;User=sa;Password=1998@hassan;";
            services.AddDbContext<ApplicationContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString(connectionString))
            options.UseSqlServer(Configuration.GetConnectionString("GestionDesAbsencesMigration"))
            );
            // services
            services.AddTransient<IProfesseurService, ProfesseurService>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IEtudiantService, EtudiantService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<ISemaineService, SemaineService>();
            services.AddTransient<ICycleService, CycleService>();
            services.AddTransient<IExcelService, ExcelService>();
            services.AddTransient<ISeanceService, SeanceService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IModuleService, ModuleService>();
            services.AddTransient<IClassService, ClassService>();
            services.AddWkhtmltopdf();

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddControllersWithViews();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                     .AddCookie(options => {
                         options.LoginPath = "/Login";
                         options.AccessDeniedPath = "/Login?accessDenied";
                         
                     });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //DatabaseManagmentService.MigrationInitialLisation(app);
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapRazorPages();
                //endpoints.MapBlazorHub();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
