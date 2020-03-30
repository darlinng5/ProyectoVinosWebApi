using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NoticiasWebApi.Services;


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
            
            //services.AddScoped<FincaAppDomain>();
            //services.AddScoped<FincaAppServices>();
            //aqui va el appDomain y el AppServices

            services.AddDbContext<DBContext>(opciones => opciones.UseSqlServer("Data Source=DESKTOP-KFVMJ2G;Initial Catalog=greencollectionsDB;Trusted_Connection=True"));
            //services.AddDbContext<DBContext>(opciones => opciones.UseSqlServer("Server = 207.246.81.54; Catálogo inicial = greencollectionsDB; Persist Security Info = False; User ID = greencollections; Password = Q% 9f68gg; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = Falso; Tiempo de espera de conexión = 30; "));

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
