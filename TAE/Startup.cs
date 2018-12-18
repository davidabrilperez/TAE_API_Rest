using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TAE.Models;

namespace TAE
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
            //services.Configure<Configuracion>(Configuration.GetSection("Configuracion"));
            //services.AddSingleton<IConfiguration>(Configuration);
            services.Add(new ServiceDescriptor(typeof(TAE.Context.BBDDContext), new TAE.Context.BBDDContext(Configuration.GetConnectionString("DefaultConnection"))));
            services.Add(new ServiceDescriptor(typeof(TAE.Models.EnvioMail), new TAE.Models.EnvioMail(Configuration["EnvioMail:email"], Configuration["EnvioMail:pass"],
                Configuration["EnvioMail:altaES"],
                Configuration["EnvioMail:altaEN"],
                Configuration["EnvioMail:altaFR"],
                Configuration["EnvioMail:altaIT"],
                Configuration["EnvioMail:altaPT"],
                Configuration["EnvioMail:recuperarES"],
                Configuration["EnvioMail:recuperarEN"],
                Configuration["EnvioMail:recuperarFR"],
                Configuration["EnvioMail:recuperarIT"],
                Configuration["EnvioMail:recuperarPT"]
                )));
            services.Add(new ServiceDescriptor(typeof(TAE.Models.WebAlmacen), new TAE.Models.WebAlmacen(
                Configuration["Web:altaES"],
                Configuration["Web:altaEN"],
                Configuration["Web:altaFR"],
                Configuration["Web:altaIT"],
                Configuration["Web:altaPT"],
                Configuration["Web:recuperarES"],
                Configuration["Web:recuperarEN"],
                Configuration["Web:recuperarFR"],
                Configuration["Web:recuperarIT"],
                Configuration["Web:recuperarPT"], 
                Configuration["Web:recuperarFinalES"],
                Configuration["Web:recuperarFinalEN"],
                Configuration["Web:recuperarFinalFR"],
                Configuration["Web:recuperarFinalIT"],
                Configuration["Web:recuperarFinalPT"]
                )));
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.AddCaching();
            services.AddSession();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSession();

            //app.UseMvc();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "");
                routes.MapRoute(
                    name: "web",
                    template: "{controller=Web}/{action=Index}/{fecha?}/{idioma?}/{email?}");
                routes.MapRoute(
                    name: "mto",
                    template: "{controller=Mto}/{action=Index}");
            });
        }
    }
}
