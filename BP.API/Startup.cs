using BP.API.Extensions;
using BP.API.Loging;
using BP.API.Models;
using BP.API.Service;
using BP.API.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;

namespace BP.API
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
               .AddFluentValidation(i => i.AutomaticValidationEnabled = true);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BP.API", Version = "v1" });
            });

            services.AddHealthChecks();

            services.ConfigureMapping();

            services.AddTransient<IValidator<ContactDVO>, ContactValidator>();

            services.AddScoped<IContactService,ContactService>();

            services.AddHttpClient("garantiapi", config =>
            {
                config.BaseAddress = new Uri("http://www.garanti.com");
                config.DefaultRequestHeaders.Add("Authorization", "Bearer 122121");
            });

            //services.AddHostedService<DateTimeLogWriter>


            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BP.API v1"));
            }

            app.UseCustomHealthCheck();

            app.UseResponseCaching();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
