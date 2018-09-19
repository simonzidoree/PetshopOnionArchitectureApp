using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Petshop.Core.ApplicationService;
using Petshop.Core.ApplicationService.Services;
using Petshop.Core.DomainService;
using Petshop.Infrastructure.Data;
using Petshop.Infrastructure.Data.RepositoriesSQL;

namespace Petshop.RESTAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            FakeDB.InitData();

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
//            services.AddDbContext<PetshopContext>(
//                opt => opt.UseInMemoryDatabase("PetshopMemoryDB")
//                );

            services.AddDbContext<PetshopContext>(
                opt => opt.UseSqlite("Data Source=petshopApp.db")
            );

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();

            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetshopContext>();
                    DBInitializer.SeedDB(ctx);
                }
            }
            else
            {
                app.UseHsts();
            }

//            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}