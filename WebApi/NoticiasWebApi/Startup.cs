using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NoticiasWebApi.Services;
using ProyectoVinowWebApi.AplicationServices;
using ProyectoVinowWebApi.AppServices;
using ProyectoVinowWebApi.Domains;

namespace NoticiasWebApi
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
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


        
            services.AddScoped<FincaAppDomain>();
            services.AddScoped<FincaAppServices>();
            services.AddScoped<LlamadaAppServices>();
            services.AddScoped<LlamadaFincaDomain>();
            services.AddScoped<ProcesoAppServices>();
            services.AddScoped<ProcesoDomain>();
            services.AddDbContext<DBContext>(opciones => opciones.UseSqlServer("Server=tcp:serverazurevinos.database.windows.net,1433;Initial Catalog=bdazurevinos;Persist Security Info=False;User ID=darlinng5;Password=D@rlinno3l2207;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

            services.AddTransient<ProyectoServices, ProyectoServices>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            //  services.AddMvc().AddJsonOptions(options => { options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; });
            services.AddCors(opciones =>
            {
                opciones.AddPolicy("PermitirTodo", acceso => acceso.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
               
            }


            app.UseCors("PermitirTodo");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(rutas=>
            {
            rutas.MapRoute(name: "default",
                           template:"{controller=Finca}/{action=getFinca}/{id?}"
                    );                
            });
        }
    }
}
