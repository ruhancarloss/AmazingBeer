using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazingBeer.Cerveja.Application;
using AmazingBeer.Cerveja.Application.AutoMapper;
using AmazingBeer.Cerveja.Domain.Interface.Repository;
using AmazingBeer.Cerveja.Domain.Interface.Service;
using AmazingBeer.Cerveja.Domain.Services;
using AmazingBeer.Cerveja.Infrastructure.DataAccess.Repositories.EFCore;
using AmazingBeer.Cerveja.Service.Api.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AmazingBeer.Cerveja.Service.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Application
            services.AddScoped<IApiAppService, ApiAppService>();

            //Repository
            services.AddScoped<ICervejaRepository, CervejaRepository>();

            //Service
            services.AddScoped<ICervejaQueryService, CervejaQueryService>();

            //AutoMapper
            services.AddAutoMapperSetup();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
