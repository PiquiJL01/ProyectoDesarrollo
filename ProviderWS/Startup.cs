using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RCVUcab.DataAccess.Database;
//using RCVUcab.Persistence.DAOs.Implementations;
//using RCVUcab.Persistence.DAOs.Interfaces;


namespace ProviderWS
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

            services.AddControllers();
            services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            /*services.AddTransient<IRCVDbContext, RCVDbContext>();
            services.AddTransient<IDataBaseContext, DataBaseContext>();
            services.AddTransient<ICotizacionDAO, CotizacionDAO>();
            services.AddTransient<IFacturaDAO, FacturaDAO>();
            services.AddTransient<IIncidenteDAO, IncidenteDAO>();
            services.AddTransient<IMarcaDAO, MarcaDAO>();
            services.AddTransient<IOrdenDeCompraDAO, OrdenDeCompraDAO>();
            services.AddTransient<IPiezaDAO, PiezaDAO>();
            services.AddTransient<IPolizaDAO, PolizaDAO>();
            services.AddTransient<IPropietarioDAO, PropietarioDAO>();
            services.AddTransient<IProveedorDAO, ProveedorDAO>();
            services.AddTransient<ITallerDAO, TallerDAO>();
            services.AddTransient<IUsuarioDAO, UsuarioDAO>();
            services.AddTransient<IVehiculoDAO, VehiculoDAO>();*/


            services.AddControllersWithViews();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RCVUcab", Version = "v1" });
            });

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

            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RCVUcab");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}