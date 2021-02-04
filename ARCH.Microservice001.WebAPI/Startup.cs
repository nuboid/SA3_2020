using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ARCH.InvoiceService;
using ARCH.Microservice001.WebAPI.Controllers;
using ARCH.Microservice001.WebAPI.Controllers.IOCDemo;
using ARCH.Repositories.Dapper.Invoice;
using Microsoft.AspNetCore.Http;

namespace ARCH.Microservice001.WebAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ARCH.Microservice001.WebAPI", Version = "v1" });
            });

            services.AddScoped<Class1>();
            services.AddScoped<Class2>();
            services.AddScoped<Class3>();
            services.AddScoped<InvoiceRepository>();
            services.AddScoped<AnotherRepository>();
            services.AddScoped<Functionality1>();
            services.AddSingleton<IdempotencyChecker>();

            services.AddHealthChecks().AddCheck<MyHealthChecks>("naam");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ARCH.Microservice001.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            //app.UseMiddleware<MyIdempotencyMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }


    public class IdempotencyChecker
    {
        private List<string> _ids = new List<string>();

        public IdempotencyChecker()
        {
            
        }
        public void RegisterIDAsCompleted(string id)
        {
            _ids.Add(id);
        }

        public bool WasAlreadyCompleted(string id)
        {
            return _ids.Contains(id);
        }
    }
    public class MyIdempotencyMiddleware
    {
       
        private readonly RequestDelegate _next;

        public MyIdempotencyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            
            var idempotencyChecker = (IdempotencyChecker)context.RequestServices.GetService(typeof(IdempotencyChecker));
            if (!idempotencyChecker.WasAlreadyCompleted("x")) // context.Request.Headers["id"]
            {
                await _next(context);
                idempotencyChecker.RegisterIDAsCompleted("x");
            }
            else
            {
                context.Response.StatusCode = 500;
            }
            
        }
    }
}
