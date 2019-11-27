using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using Microsoft.EntityFrameworkCore;
using StartupService.Models;

namespace StartupService
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
            services.AddDbContext<StartupDbContext>(opt => opt.UseInMemoryDatabase("Startups"), ServiceLifetime.Singleton);
            services.AddOData();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var db = app.ApplicationServices.GetRequiredService<StartupDbContext>();
            DataSource.SeedDatabase(db);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseODataBatching();
            app.UseMvc(routeBuilder =>
            {
                var odataBatchHandler = new DefaultODataBatchHandler();
                routeBuilder.Select().Filter().Expand().MaxTop(100).OrderBy().Count();
                routeBuilder.MapODataServiceRoute("ODataRoute", "odata", StartupEdmModel.GetEdmModel(), odataBatchHandler);
            });
        }
    }
}
