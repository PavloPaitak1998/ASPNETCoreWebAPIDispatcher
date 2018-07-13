using DataAccessLayer.Interfaces;
using DataAccessLayer.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Implementation.UnitOfWork;
using FluentValidation.AspNetCore;
using Shared.Validators;
using Shared.DTO;

namespace WebAppAirlineDispatcher
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
            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<FlightDTOValidator>());
            services.AddTransient<IEntityService<FlightDTO>, FlightService>();
            services.AddTransient<IEntityService<TicketDTO>, TicketService>();
            services.AddTransient<IEntityService<StewardessDTO>, StewardessService>();
            services.AddTransient<IEntityService<PilotDTO>, PilotService>();
            services.AddTransient<IEntityService<PlaneDTO>, PlaneService>();
            services.AddTransient<IEntityService<CrewDTO>, CrewService>();
            services.AddTransient<IEntityService<PlaneTypeDTO>, PlaneTypeService>();
            services.AddTransient<IEntityService<DepartureDTO>, DepartureService>();
            services.AddSingleton<IDataSource, DataSource>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
