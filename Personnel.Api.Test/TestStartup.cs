using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Personnel.Data.Contracts;
using Personnel.Data.Repositories;

namespace Personnel.Api.Test
{
    public class TestStartup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public TestStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PersonnelDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
                });

            services.AddScoped<IPersonnelRepository, PersonnelRepository>();
            services.AddControllers();
            //Mock your repositories.
            TestInitializer.RegisterMockRepositories(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(MyAllowSpecificOrigins);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

           

            app.UseAuthorization();


            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
