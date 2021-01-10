using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ClientService.Repositories;
using ClientService.Mappings;
using ClientService.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;
using ClientService.Services;
using System.IO;
using System;

namespace LCPClientService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ClientContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ClientContext")));
            services
                .AddOptions<BlobStorageConfiguration>()
                .Bind(Configuration.GetSection("BlobStorage"));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddControllers();
            services.AddSwaggerGen(c => {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });
            services.AddMvc().AddFluentValidation();
            services.AddAutoMapper(typeof(ClientDetailsProfile));
            services.AddTransient<IClientDetailsRepository, ClientDetailsRepository>();
            services.AddTransient<IClientDetailsService, ClientDetailsService>();
            services.AddTransient<IClientDetailsUploader, ClientDetailsUploader>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("swagger/v1/swagger.json", "Client Service");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
