using System;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using ODataDemo.Common.Helpers;
using ODataDemo.Common.Models;

namespace ODataDemo
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
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase());
            services.AddOData();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var context = app.ApplicationServices.GetService<DataContext>();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel(app.ApplicationServices));
            });
        }

        private IEdmModel GetEdmModel(IServiceProvider serviceProvider)
        {
            var builder = new ODataConventionModelBuilder(serviceProvider);

            builder.EntitySet<Comment>("Comments")
                            .EntityType
                            .Filter() // Allow for the $filter Command
                            .Count() // Allow for the $count Command
                            .Expand() // Allow for the $expand Command
                            .OrderBy() // Allow for the $orderby Command
                            .Page() // Allow for the $top and $skip Commands
                            .Select();// Allow for the $select Command; 

            builder.EntitySet<User>("Users")
                            .EntityType
                            .Filter() // Allow for the $filter Command
                            .Count() // Allow for the $count Command
                            .Expand() // Allow for the $expand Command
                            .OrderBy() // Allow for the $orderby Command
                            .Page() // Allow for the $top and $skip Commands
                            .Select() // Allow for the $select Command
                            .ContainsMany(x => x.Comments)
                            .Expand();

            return builder.GetEdmModel();
        }
    }
}
