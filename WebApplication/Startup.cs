using FluentValidation.AspNetCore;
using Hqv.Dominoes.WebApplication.Components;
using Hqv.Dominoes.WebApplication.Services;
using Hqv.Dominoes.WebApplication.Setup;
using Hqv.Dominoes.WebApplication.Setup.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Prometheus;
using Serilog;

namespace Hqv.Dominoes.WebApplication
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
            services.AddControllers()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<Startup>(lifetime: ServiceLifetime.Singleton);
                    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                    fv.ImplicitlyValidateChildProperties = true;
                });
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebApplication", Version = "v1"});
            });
            
            services.AddAutoMapper(typeof(Startup));

            services.AddOptions();
            services.Configure<KafkaProducerOptions>(Configuration.GetSection(KafkaProducerOptions.ConfigurationName));
            
            services.AddSingleton<GameService>();
            services.AddSingleton<IPublisher, KafkaPublisher>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dominoes WebApplication v1"));
            }
            
            app.UseSetDefaultHeaders();
            app.UseLogDefaultHeaders();
            app.UseSerilogRequestLogging();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            // Prometheus
            app.UseHttpMetrics();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapMetrics();
                endpoints.MapControllers();
            });
        }
    }
}