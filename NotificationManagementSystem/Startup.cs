using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NotificationManagementSystem.Controllers;
using NotificationManagementSystem.Data;
using NotificationManagementSystem.Helpers;
using NotificationManagementSystem.Services;

namespace NotificationManagementSystem
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

            services.AddDbContext<MessageDbContext>();
            services.AddDbContext<MessageDbContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("DBconnectionString")));


            services.AddScoped<IMessageRepository, MessageRepository>();



            services.AddControllers();

            // configure strongly typed settings object
            services.Configure<MessageSettings>(Configuration.GetSection("MessageSettings"));
            services.Configure<SendGridSettings>(Configuration.GetSection("SendGridSettings"));
            services.Configure<TwilioSettings>(Configuration.GetSection("TwilioSettings"));

            // configure DI for application services
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<MessageController>();

            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Notification Management Service", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Notification Management Service");
            });
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
