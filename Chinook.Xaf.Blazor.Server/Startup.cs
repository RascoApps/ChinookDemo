using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Blazor.Reporting;
using DevExpress.ExpressApp.ReportsV2.Blazor;
using DevExpress.ExpressApp.Blazor.Services;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EFCore.AuditTrail;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Chinook.Xaf.Blazor.Server.Services;
using DevExpress.ExpressApp.WebApi.Services;
using DevExpress.ExpressApp.WebApi.Swashbuckle;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.OData;

namespace Chinook.Xaf.Blazor.Server {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddSingleton(typeof(Microsoft.AspNetCore.SignalR.HubConnectionHandler<>), typeof(ProxyHubConnectionHandler<>));

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpContextAccessor();
            services.AddScoped<CircuitHandler, CircuitHandlerProxy>();
            services.AddXaf<XafBlazorApplication>(Configuration);
            services.AddXafReporting();
            services.AddDbContextFactory<Chinook.Xaf.Module.BusinessObjects.XafEFCoreDbContext>((serviceProvider, options) => {
                // Uncomment this code to use an in-memory database. This database is recreated each time the server starts. With the in-memory database, you don't need to make a migration when the data model is changed.
                // Do not use this code in production environment to avoid data loss.
                // We recommend that you refer to the following help topic before you use an in-memory database: https://docs.microsoft.com/en-us/ef/core/testing/in-memory
                //options.UseInMemoryDatabase("InMemory");
                string connectionString = Configuration.GetConnectionString("ConnectionString");
                options.UseSqlServer(connectionString);
                options.UseLazyLoadingProxies();
                options.UseAudit();
            }, ServiceLifetime.Scoped);
            services.AddDbContextFactory<Chinook.Xaf.Module.BusinessObjects.XafAuditingDbContext>((serviceProvider, options) => {
                string connectionString = Configuration.GetConnectionString("ConnectionString");
                options.UseSqlServer(connectionString);
                options.UseLazyLoadingProxies();
            }, ServiceLifetime.Scoped);
            services.AddAuditTrail(options => {
                options.AuditUserProviderType = typeof(AuditEmptyUserProvider);
            }).AddAuditedDbContextFactory<Chinook.Xaf.Module.BusinessObjects.XafEFCoreDbContext, Chinook.Xaf.Module.BusinessObjects.XafAuditingDbContext>();
            services.AddXafWebApi(options => {
                // Use options.BusinessObject<YourBusinessObject>() to make the Business Object available in the Web API and generate the GET, POST, PUT, and DELETE HTTP methods for it.
            });
            services.AddControllers().AddOData(options => {
            });
            services.AddSwaggerGen(c => {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "Chinook.Xaf API",
                    Version = "v1",
                    Description = @"Use AddXafWebApi(options) in the Chinook.Xaf.Blazor.Server\Startup.cs file to make Business Objects available in the Web API."
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Chinook.Xaf WebApi v1");
                });
            }
            else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. To change this for production scenarios, see: https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseRequestLocalization();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseXaf();
            app.UseDevExpressBlazorReporting();
            app.UseEndpoints(endpoints => {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
                endpoints.MapControllers();
            });
        }
    }
}
